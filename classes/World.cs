using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes
{
    internal class World
    {
        public World() { }

        int WorldSize;

        public void Init(int size)
        {
            if (size <= 0)
            {
                return;
            }

            this.WorldSize = size;
        }
    }
}
