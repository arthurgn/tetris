
namespace sequor.testris
{
    partial class FrmTetris
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTetris));
            this.BtnNovo = new System.Windows.Forms.Button();
            this.BtnResetar = new System.Windows.Forms.Button();
            this.BtnPausar = new System.Windows.Forms.Button();
            this.TbPontos = new System.Windows.Forms.TextBox();
            this.tabuleiroPreview1 = new sequor.testris.Componentes.TabuleiroPreview();
            this.tabuleiro1 = new sequor.testris.Componentes.Tabuleiro();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnContinuar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNovo
            // 
            this.BtnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNovo.Location = new System.Drawing.Point(274, 103);
            this.BtnNovo.Name = "BtnNovo";
            this.BtnNovo.Size = new System.Drawing.Size(88, 28);
            this.BtnNovo.TabIndex = 1;
            this.BtnNovo.Text = "Novo";
            this.BtnNovo.UseVisualStyleBackColor = true;
            this.BtnNovo.Click += new System.EventHandler(this.BtnNovo_Click);
            // 
            // BtnResetar
            // 
            this.BtnResetar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnResetar.Location = new System.Drawing.Point(462, 105);
            this.BtnResetar.Name = "BtnResetar";
            this.BtnResetar.Size = new System.Drawing.Size(88, 28);
            this.BtnResetar.TabIndex = 3;
            this.BtnResetar.Text = "Resetar";
            this.BtnResetar.UseVisualStyleBackColor = true;
            this.BtnResetar.Click += new System.EventHandler(this.BtnResetar_Click);
            // 
            // BtnPausar
            // 
            this.BtnPausar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPausar.Location = new System.Drawing.Point(368, 105);
            this.BtnPausar.Name = "BtnPausar";
            this.BtnPausar.Size = new System.Drawing.Size(88, 28);
            this.BtnPausar.TabIndex = 5;
            this.BtnPausar.Text = "Pausar";
            this.BtnPausar.UseVisualStyleBackColor = true;
            this.BtnPausar.Click += new System.EventHandler(this.BtnPausar_Click);
            // 
            // TbPontos
            // 
            this.TbPontos.Enabled = false;
            this.TbPontos.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbPontos.Location = new System.Drawing.Point(274, 204);
            this.TbPontos.Name = "TbPontos";
            this.TbPontos.ReadOnly = true;
            this.TbPontos.Size = new System.Drawing.Size(276, 62);
            this.TbPontos.TabIndex = 6;
            this.TbPontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabuleiroPreview1
            // 
            this.tabuleiroPreview1.Location = new System.Drawing.Point(274, 0);
            this.tabuleiroPreview1.Name = "tabuleiroPreview1";
            this.tabuleiroPreview1.Size = new System.Drawing.Size(276, 97);
            this.tabuleiroPreview1.TabIndex = 4;
            // 
            // tabuleiro1
            // 
            this.tabuleiro1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabuleiro1.Girar = false;
            this.tabuleiro1.Location = new System.Drawing.Point(0, 0);
            this.tabuleiro1.MoverDireita = false;
            this.tabuleiro1.MoverEsquerda = false;
            this.tabuleiro1.Name = "tabuleiro1";
            this.tabuleiro1.Pontuacao = 0;
            this.tabuleiro1.Size = new System.Drawing.Size(250, 403);
            this.tabuleiro1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(256, -24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(5, 480);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.Location = new System.Drawing.Point(274, 363);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(120, 28);
            this.BtnSalvar.TabIndex = 8;
            this.BtnSalvar.Text = "Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnContinuar
            // 
            this.BtnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContinuar.Location = new System.Drawing.Point(434, 363);
            this.BtnContinuar.Name = "BtnContinuar";
            this.BtnContinuar.Size = new System.Drawing.Size(120, 28);
            this.BtnContinuar.TabIndex = 9;
            this.BtnContinuar.Text = "Continuar";
            this.BtnContinuar.UseVisualStyleBackColor = true;
            this.BtnContinuar.Click += new System.EventHandler(this.BtnContinuar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(400, 363);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // FrmTetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 403);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnContinuar);
            this.Controls.Add(this.BtnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TbPontos);
            this.Controls.Add(this.BtnPausar);
            this.Controls.Add(this.tabuleiroPreview1);
            this.Controls.Add(this.BtnResetar);
            this.Controls.Add(this.BtnNovo);
            this.Controls.Add(this.tabuleiro1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTetris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris 1.0";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTetris_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Componentes.Tabuleiro tabuleiro1;
        private System.Windows.Forms.Button BtnNovo;
        private System.Windows.Forms.Button BtnResetar;
        private Componentes.TabuleiroPreview tabuleiroPreview1;
        private System.Windows.Forms.Button BtnPausar;
        private System.Windows.Forms.TextBox TbPontos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnContinuar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}