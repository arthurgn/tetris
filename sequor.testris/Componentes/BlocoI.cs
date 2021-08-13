using sequor.testris.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace sequor.testris.Componentes
{
    public class BlocoI : absBloco
    {

        public BlocoI(Enums.TiposAngulo tipoAngulo)
        {
            Cor = Color.Yellow;

            Blocos = new List<Bloco>();

            TipoAngulo = tipoAngulo;

            Guid = Guid.NewGuid();

            Girar();

            TipoAngulo = tipoAngulo;
        }

        public override void Mover(List<absBloco> absBlocos, int X, int Y)
        {
            var pecaTravadas = absBlocos.Where(x => x.Travou).ToList();

            foreach (var blocoMovendo in Blocos)
            {
                if (X < 0)
                {
                    if (blocoMovendo.Location.X + X < 0)
                        return;
                }
                else
                {

                    if (blocoMovendo.Location.X + X > 225)
                        return;
                }

                if (blocoMovendo.Location.Y + Y > 375)
                {
                    Travou = true;
                    return;
                }

                foreach (var pecaTravada in pecaTravadas)
                    foreach (var blocoTravado in pecaTravada.Blocos.Where(x => !x.Removeu))
                    {
                        if (blocoTravado.Location.Y == blocoMovendo.Location.Y + Y)
                        {
                            if (blocoTravado.Location.X == blocoMovendo.Location.X + X)
                            {
                                Travou = true;
                                return;
                            }
                        }
                    }
            }

            foreach (var Bloco in Blocos)
            {
                Bloco.Location = new Point(Bloco.Location.X + X, Bloco.Location.Y + Y);
            }
        }
        public override void Girar()
        {
            switch (TipoAngulo)
            {
                case Enums.TiposAngulo._0:
                    {
                        if (Blocos.Count == 0)
                        {
                            Blocos = new List<Bloco>
                            {
                                new Bloco(Cor) { Location = new Point(0, 0) },
                                new Bloco(Cor) { Location = new Point(0, 25) },
                                new Bloco(Cor) { Location = new Point(0, 50) },
                                new Bloco(Cor) { Location = new Point(0, 75) },
                            };
                        }
                        else
                        {
                            Blocos[0].Location = new Point(Blocos[0].Location.X, Blocos[0].Location.Y);
                            Blocos[1].Location = new Point(Blocos[1].Location.X + 25, Blocos[0].Location.Y - 0);
                            Blocos[2].Location = new Point(Blocos[2].Location.X + 50, Blocos[0].Location.Y - 0);
                            Blocos[3].Location = new Point(Blocos[3].Location.X + 75, Blocos[0].Location.Y - 0);
                        }
                        TipoAngulo = Enums.TiposAngulo._90;
                        break;
                    }
                case Enums.TiposAngulo._90:
                    {

                        if (Blocos.Count == 0)
                        {
                            Blocos = new List<Bloco>
                            {
                                new Bloco(Cor) { Location = new Point(0, 0) },
                                new Bloco(Cor) { Location = new Point(25, 0) },
                                new Bloco(Cor) { Location = new Point(50, 0) },
                                new Bloco(Cor) { Location = new Point(75, 0) },
                            };
                        }
                        else
                        {
                            Blocos[0].Location = new Point(Blocos[0].Location.X, Blocos[0].Location.Y);
                            Blocos[1].Location = new Point(Blocos[0].Location.X - 0, Blocos[1].Location.Y - 25);
                            Blocos[2].Location = new Point(Blocos[0].Location.X - 0, Blocos[2].Location.Y - 50);
                            Blocos[3].Location = new Point(Blocos[0].Location.X - 0, Blocos[3].Location.Y - 75);
                        }
                        TipoAngulo = Enums.TiposAngulo._0;
                        break;
                    }
            }
        }
    }
}
