using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace sequor.testris.Componentes
{
    public partial class Tabuleiro : Panel
    {
        public List<absBloco> Blocos { get; set; }
        public bool TemPeca
        {
            get
            {
                return Blocos.FirstOrDefault(x => !x.Travou) != null;
            }
        }
        public bool MoverEsquerda { get; set; }
        public bool MoverDireita { get; set; }
        public bool Girar { get; set; }
        public int Pontuacao { get; set; }
        public bool Pausado { get; set; }

        public Tabuleiro()
        {
            InitializeComponent();

            Blocos = new List<absBloco>();
        }

        public void Mover()
        {
            foreach (var Bloco in Blocos)
            {
                if (!Bloco.Travou)
                {
                    if (Girar)
                    {
                        Bloco.Girar();

                        Girar = false;
                    }
                    else if (MoverEsquerda)
                    {
                        Bloco.Mover(Blocos, -25, 0);
                        MoverEsquerda = false;
                    }
                    else if (MoverDireita)
                    {
                        Bloco.Mover(Blocos, 25, 0);
                        MoverDireita = false;
                    }

                    Bloco.Mover(Blocos, 0, 25);
                }
            }
        }
        public void ResetarJogo()
        {
            Pontuacao = 0;

            Controls.Clear();

            Blocos = new List<absBloco>();
        }
        public void VerificaLinhaCompleta()
        {
            var absBlocos = Blocos.Cast<absBloco>().Where(x => x.Travou).ToList();

            var dicLinhas = new Dictionary<int, List<Bloco>>();

            for (int y = 16; y >= 0; y--)
            {
                for (int x = 0; x < 10; x++)
                {
                    foreach (var absBloco in absBlocos)
                    {
                        foreach (var bloco in absBloco.Blocos)
                        {
                            if (bloco.Location.X == (x * 25) && bloco.Location.Y == (y * 25))
                            {
                                if (dicLinhas.ContainsKey(y))
                                    dicLinhas[y].Add(bloco);
                                else
                                    dicLinhas.Add(y, new List<Bloco>() { bloco });
                            }
                        }
                    }
                }
            }

            foreach (var dicLinha in dicLinhas)
            {
                if (dicLinha.Value.Count == 10)
                {
                    Pontuacao += dicLinha.Value.Sum(x => x.Pontos);

                    foreach (var blocoLinhaCompleta in dicLinha.Value)
                    {
                        blocoLinhaCompleta.Removeu = true;

                        blocoLinhaCompleta.Location = new System.Drawing.Point(1000, 1000);
                        Controls.Remove(blocoLinhaCompleta);
                    }

                    foreach (var absBloco in absBlocos)
                        absBloco.DesceUm();
                }
            }

            var _absBlocos = new List<absBloco>();

            foreach (var absBloco in absBlocos)
                if (absBloco.Blocos.Where(x => x.Removeu).Count() != absBloco.Blocos.Count)
                    _absBlocos.Add(absBloco);

            Blocos = _absBlocos;
        }
    }
}