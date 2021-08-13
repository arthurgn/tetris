using System;
using System.Drawing;
using System.Windows.Forms;

namespace sequor.testris.Componentes
{
    public partial class Bloco : UserControl
    {
        public Guid Guid { get; }
        public int Pontos { get; }
        public bool Removeu { get; set; }

        public Bloco(object Cor = null)
        {
            Guid = Guid.NewGuid();

            InitializeComponent();

            BackColor = Color.Transparent;
            BorderStyle = BorderStyle.None;
            PbCor.BackColor = Color.Transparent;
            PbCor.SizeMode = PictureBoxSizeMode.StretchImage;
            PbCor.BackgroundImageLayout = ImageLayout.None;

            if (Cor != null)
            {
                PbCor.BackColor = (Color)Cor;
                BorderStyle = BorderStyle.Fixed3D;

                if (((Color)Cor) == Color.Red) Pontos = 7;
                else if (((Color)Cor) == Color.Maroon) Pontos = 9;
                else if (((Color)Cor) == Color.Green) Pontos = 11;
                else if (((Color)Cor) == Color.Blue) Pontos = 5;
                else if (((Color)Cor) == Color.Yellow) Pontos = 19;
            }
        }
    }
}