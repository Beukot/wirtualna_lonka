using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes.plants
{
    internal class Milkweed : Plant
    {
        public Milkweed() : base(health: 40, initiative: 0, strength: 0, agility: 0, multiplyChance: 0.4, imageSource: "images/milkweed.png")
        {
            name = "Mlecz";
        }
    }
}
