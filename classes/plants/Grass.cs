using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes.plants
{
    internal class Grass : Plant
    {
        public Grass() : base(health: 40, initiative: 0, strength: 0, agility: 0, multiplyChance: 0.4, imageSource: "images/grass.png")
        {
            name = "Trawa";
        }
    }
}
