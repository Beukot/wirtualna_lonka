using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes.animals
{
    internal class Sheep : Animal
    {
        public Sheep() : base(health: 80, initiative: 4, strength: 4, agility: 5, multiplyChance: 0.5, imageSource: "images/sheep.png")
        {
            name = "Sheep";
        }

        public override void Action()
        {
            Move();
        }

        public override Organism Mutation()
        {
            return new Sheep();
        }

        public override void Multiply()
        {
            Random r = new Random();
            if (r.NextDouble() < multiplyChance)
            {
                // Logic to add a new Sheep to the world would go here
            }
        }
    }
}
