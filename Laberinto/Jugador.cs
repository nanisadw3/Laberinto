using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laberinto
{
    internal class Jugador
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Jugador()
        {

        }
        public Jugador(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
