using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes
{
    struct Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetPos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position GetPos()
        {
            return this;
        }
    }
}
