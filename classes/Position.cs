using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override string ToString()
        {
            return X.ToString() + ", " + Y.ToString();
        }
    }
}