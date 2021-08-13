using sequor.testris.Classes;
using sequor.testris.Componentes;
using sequor.testris.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace sequor.testris
{
    public partial class FrmTetris : Form
    {
        Timer TmrTetris { get; set; }
        DbAcess Db { get; set; }

        public FrmTetris()
        {
            InitializeComponent();

            Text = "TETRIS 1.0";

            Load += FrmTetris_Load;
        }

        #region Metodos
        private void ObtemPeca()
        {
            var absBloco = tabuleiroPreview1.ObtemBloco();

            tabuleiroPreview1.ZerarPeca();

            var rnd = new Random();

            var comeco = 0;
            comeco = rnd.Next(0, 6);
            if (comeco > 0)
                comeco *= 25;

            foreach (var Bloco in absBloco.Blocos)
                Bloco.Location = new Point(Bloco.Location.X + comeco, Bloco.Location.Y);

            tabuleiro1.Blocos.Add(absBloco);
            tabuleiro1.Controls.AddRange(absBloco.Blocos.ToArray());
        }
        public void CriaTabelas()
        {
            try { Db.ExecuteNonQuery("CREATE TABLE Jogo (    Id int IDENTITY(1, 1) NOT NULL, Pontos int,    [DtSalvo][datetime2](7) NOT NULL)", true); }
            catch
            { }
            try { Db.ExecuteNonQuery("CREATE TABLE JogoDados ( Id int IDENTITY(1,1) NOT NULL, [FkJogo][int] NOT NULL, [Blocos][text])", true); }
            catch
            { }
        }
        public bool VerificaGameOver()
        {
            foreach (var absBloco in tabuleiro1.Blocos.Where(x => x.Travou))
                foreach (var bloco in absBloco.Blocos)
                    if (bloco.Location.Y == 0)
                    {
                        TmrTetris.Stop();

                        MessageBox.Show("Game Over!!");

                        tabuleiroPreview1.ResetarJogo();
                        tabuleiroPreview1.ZerarPeca();
                        tabuleiro1.ResetarJogo();

                        BtnNovo.Enabled = true;
                        BtnContinuar.Enabled = true;
                        BtnResetar.Enabled = false;
                        BtnPausar.Enabled = false;

                        tabuleiro1.Pontuacao = 0;
                        TbPontos.Text = tabuleiro1.Pontuacao.ToString();

                        return true;
                    }

            return false;
        }

        #endregion

        #region Eventos
        private void FrmTetris_Load(object sender, EventArgs e)
        {
            MinimizeBox = true;

            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var stream = assembly.GetManifestResourceStream("sequor.testris.fundo.jpg");
                var image = Image.FromStream(stream);
                tabuleiro1.BackgroundImage = image;
            }
            catch
            { }

            pictureBox1.Click += PictureBox1_Click;

            BtnSalvar.Enabled = false;
            BtnPausar.Enabled = false;
            BtnResetar.Enabled = false;

            TmrTetris = new Timer();
            TmrTetris.Interval = Configuracao.Dificuldade;
            TmrTetris.Tick += TmrTetris_Tick;
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("sequor.testris.tetris.mp3");
            var mp3 = Image.FromStream(stream);
        }
        private void BtnResetar_Click(object sender, EventArgs e)
        {
            TmrTetris.Stop();

            if (MessageBox.Show("Confirma resetar o jogo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabuleiroPreview1.ResetarJogo();
                tabuleiroPreview1.ZerarPeca();
                tabuleiro1.ResetarJogo();

            }

            TmrTetris.Start();
            TbPontos.Text = tabuleiro1.Pontuacao.ToString();
        }
        private void TmrTetris_Tick(object sender, EventArgs e)
        {
            TbPontos.Text = tabuleiro1.Pontuacao.ToString();

            if (tabuleiroPreview1.ObtemBloco() == null)
                tabuleiroPreview1.CriarPeca();

            if (!tabuleiro1.TemPeca)
            {
                TmrTetris.Interval = Configuracao.Dificuldade;

                TmrTetris.Stop();
                tabuleiro1.VerificaLinhaCompleta();
                TmrTetris.Start();

                ObtemPeca();
            }
            else
            {
                if (!VerificaGameOver())
                    tabuleiro1.Mover();
            }
        }
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            TmrTetris.Start();

            BtnNovo.Enabled = false;
            BtnPausar.Enabled = true;
            BtnResetar.Enabled = true;
            BtnContinuar.Enabled = false;
        }
        private void FrmTetris_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                tabuleiro1.MoverEsquerda = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                tabuleiro1.MoverDireita = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                TmrTetris.Interval = 50;
            }
            else if (e.KeyCode == Keys.Up)
            {
                tabuleiro1.Girar = true;
            }
        }
        private void BtnPausar_Click(object sender, EventArgs e)
        {
            if (tabuleiro1.Pausado)
            {
                if (MessageBox.Show("Continuar jogo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TmrTetris.Start();
                }
            }
            else
            {
                TmrTetris.Stop();

                if (MessageBox.Show("Pausar o jogo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BtnSalvar.Enabled = true;
                    BtnPausar.Text = "Continuar";
                    tabuleiro1.Pausado = true;
                }
                else TmrTetris.Start();
            }
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            FrmTetris_Load(this, EventArgs.Empty);


            if (Db == null)
                Db = new DbAcess(new SqlConnection("Data Source=localhost;Initial Catalog=tetris;User Id=sequor;Password=" +
                    "sequor;Trusted_Connection=False;Connect Timeout=100000"));

            CriaTabelas();

            var jogo = new Jogo();
            jogo.DtSalvo = DateTime.Now;
            jogo.Pontos = tabuleiro1.Pontuacao; ;


            var id = Db.ExecuteNonQuery("INSERT INTO[dbo].[jogo] ([dtsalvo], [pontos]) VALUES ( @dtsalvo , @pontos)", true,
                Db.ToDbParameter(jogo.DtSalvo, "dtsalvo"),
                Db.ToDbParameter(jogo.Pontos, "pontos"));

            var jogodados = new JogoDados();
            jogodados.FkJogo = id;


            foreach (var bloco in tabuleiro1.Blocos)
                bloco.MontarPosicoes();

            jogodados.Blocos = Serializador.JSON.Salvar(tabuleiro1.Blocos.Where(x => x.Travou));

            Db.ExecuteNonQuery("INSERT INTO [dbo].[jogoDados] ([fkJogo] ,[blocos] ) VALUES " +
                "( @fkJogo,  @blocosLista )", true,
                Db.ToDbParameter(jogodados.FkJogo, "fkJogo"),
                Db.ToDbParameter(jogodados.Blocos, "blocosLista"));


            tabuleiroPreview1.ResetarJogo();
            tabuleiroPreview1.ZerarPeca();
            tabuleiro1.ResetarJogo();

            tabuleiro1.Pausado = false;
            BtnPausar.Text = "Pausar";

            BtnNovo.Enabled = true;
            BtnContinuar.Enabled = true;

            tabuleiro1.Pontuacao = 0;
            TbPontos.Text = tabuleiro1.Pontuacao.ToString();

            MessageBox.Show("Jogo Salvo!");
        }
        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Continuar do ultimo jogo salvo?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (Db == null)
                    Db = new DbAcess(new SqlConnection("Data Source=localhost;Initial Catalog=tetris;User Id=sequor;Password=" +
                        "sequor;Trusted_Connection=False;Connect Timeout=100000"));

                var jogo = Db.ExecuteReaderToList<Jogo>("select * from jogo order by dtsalvo desc").FirstOrDefault();
                if (jogo != null)
                {
                    var jogosalvo = Db.ExecuteReaderToObject<JogoDados>("select * from jogodados where fkjogo=" + jogo.Id);

                    tabuleiro1.Blocos = Serializador.JSON.Ler<List<absBloco>>(jogosalvo.Blocos);
                    tabuleiro1.Controls.Clear();

                    foreach (var b in tabuleiro1.Blocos)
                    {
                        b.Blocos.Clear();
                        foreach (var p in b.Posicoes)
                            b.Blocos.Add(new Bloco(b.Cor) { Location = new Point(p.X, p.Y), Removeu = p.Removeu });

                        foreach (var bloco in b.Blocos)
                            tabuleiro1.Controls.Add(bloco);
                    }

                    tabuleiro1.Pontuacao = jogo.Pontos;

                    TbPontos.Text = tabuleiro1.Pontuacao.ToString();

                    BtnPausar.Enabled = true;

                    BtnResetar.Enabled = true;

                    BtnNovo_Click(this, EventArgs.Empty);
                }
                else MessageBox.Show("nenhum jogo encontrado!");
            }
        }
        #endregion
    }
}