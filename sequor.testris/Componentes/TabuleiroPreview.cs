using sequor.testris.Classes;
using System;
using System.Windows.Forms;

namespace sequor.testris.Componentes
{
    public partial class TabuleiroPreview : Panel
    {
        public TabuleiroPreview()
        {
            InitializeComponent();
        }

        public absBloco absBloco;

        internal void CriarPeca()
        {
            var Random = new Random();

            var TipoBloco = Configuracao.TiposBlocos[Random.Next(0, Configuracao.TiposBlocos.Count)];
            var AngulosTodos = Configuracao.AngulosTodos[Random.Next(0, Configuracao.AngulosTodos.Count)];
            var Angulo0E90 = Configuracao.Angulos0E90[Random.Next(0, Configuracao.Angulos0E90.Count)];

            AngulosTodos = Enums.TiposAngulo._0;

            switch (TipoBloco)
            {               
                case Enums.TiposBloco.Z:
                    absBloco = new BlocoZ(Angulo0E90);
                    break;
                case Enums.TiposBloco.T:
                    absBloco = new BlocoT(AngulosTodos);
                    break;               
                case Enums.TiposBloco.I:
                    absBloco = new BlocoI(Angulo0E90);
                    break;
                case Enums.TiposBloco.J:
                    absBloco = new BlocoJ(Angulo0E90);
                    break;
                case Enums.TiposBloco.O:
                    absBloco = new BlocoO();
                    break;
            }

            Controls.Clear();

            Controls.AddRange(absBloco.Blocos.ToArray());
        }
        internal void ResetarJogo()
        {
            Controls.Clear();
        }
        internal void ZerarPeca()
        {
            absBloco = null;
        }
        internal absBloco ObtemBloco()
        {
            return absBloco;
        }
    }
}
