using System.Collections.Generic;

namespace sequor.testris.Classes
{
    class Configuracao
    {
        public static int Dificuldade = 250;
 
        public static List<Enums.TiposBloco> TiposBlocos = new List<Enums.TiposBloco>()
        {
            Enums.TiposBloco.T,
            Enums.TiposBloco.Z,
            Enums.TiposBloco.O,
            Enums.TiposBloco.J,
            Enums.TiposBloco.I,
        };
        public static List<Enums.TiposAngulo> AngulosTodos = new List<Enums.TiposAngulo>()
        {
            Enums.TiposAngulo._180,
            Enums.TiposAngulo._270,
            Enums.TiposAngulo._90,
            Enums.TiposAngulo._0
        };
        public static List<Enums.TiposAngulo> Angulos0E90 = new List<Enums.TiposAngulo>()
        {
            Enums.TiposAngulo._0,
            Enums.TiposAngulo._90,
        };
    }
}