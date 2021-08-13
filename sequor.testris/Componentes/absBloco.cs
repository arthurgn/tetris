using Newtonsoft.Json;
using sequor.testris.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace sequor.testris.Componentes
{
    public abstract class absBloco
    {
        public absBloco()
        {
        }

        public abstract void Mover(List<absBloco> Controls, int X, int Y);
        public abstract void Girar();


        [JsonIgnore]
        public List<Bloco> Blocos { get; set; }
        public Enums.TiposAngulo TipoAngulo { get; set; }
        public Enums.TiposBloco TipoBloco { get; set; }

        public bool Travou { get; set; }
        public Guid Guid { get; set;  }
        public Color Cor { get; set;  }
        public List<Posicao> Posicoes { get; set; }


        public void DesceUm()
        {
            foreach (var Bloco in Blocos)
                if (!Bloco.Removeu)
                    if (Bloco.Location.Y + 25 < 400)
                        Bloco.Location = new Point(Bloco.Location.X, Bloco.Location.Y + 25);
        }
        public void MontarPosicoes()
        {
            {
                var o = new List<Posicao>();
                foreach (var b in Blocos)
                {
                    o.Add(new Posicao()
                    {
                        X = b.Location.X,
                        Y = b.Location.Y,
                        Removeu = b.Removeu
                    });
                }
                Posicoes = o;
            }
        }
        public void MontarBlocos()
        {
            {
                foreach (var bloco in Blocos)
                {



                }




                var o = new List<Posicao>();
                foreach (var b in Blocos)
                {
                    o.Add(new Posicao()
                    {
                        X = b.Location.X,
                        Y = b.Location.Y,
                        Removeu = b.Removeu
                    });
                }
                Posicoes = o;
            }
        } 
    }
}
