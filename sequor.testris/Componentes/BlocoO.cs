using sequor.testris.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace sequor.testris.Componentes
{
    public class BlocoO : absBloco
    {


        public BlocoO()
        {
            Cor = Color.Blue;

            Guid = Guid.NewGuid();

            Blocos = new List<Bloco>
            {
                new Bloco(Cor) { Location = new Point(0, 0) },
                new Bloco(Cor) { Location = new Point(25, 0) },
                new Bloco(Cor) { Location = new Point(0, 25) },
                new Bloco(Cor) { Location = new Point(25, 25) }
            };
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
                    foreach (var blocoTravado in pecaTravada.Blocos)
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

        }
    }
}
