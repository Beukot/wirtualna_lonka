using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes
{
    internal class Plant : Organism
    {
        public Plant(double health, double initiative, double strenght, double agility, double multiplyChance, string imageSource) : base(health, initiative, strenght, agility, multiplyChance, imageSource)
        {
        }

        public override void Action()
        {
            throw new NotImplementedException();
        }

        public override void Multiply()
        {
            throw new NotImplementedException();
        }

        public override Organism Mutation()
        {
            throw new NotImplementedException();
        }
    }
}
