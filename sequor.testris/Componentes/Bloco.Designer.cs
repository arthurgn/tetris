
namespace sequor.testris.Componentes
{
    partial class Bloco
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PbCor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbCor)).BeginInit();
            this.SuspendLayout();
            // 
            // PbCor
            // 
            this.PbCor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbCor.Location = new System.Drawing.Point(0, 0);
            this.PbCor.Name = "PbCor";
            this.PbCor.Size = new System.Drawing.Size(25, 25);
            this.PbCor.TabIndex = 1;
            this.PbCor.TabStop = false;
            // 
            // Bloco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PbCor);
            this.Name = "Bloco";
            this.Size = new System.Drawing.Size(25, 25);
            ((System.ComponentModel.ISupportInitialize)(this.PbCor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbCor;
    }
}
