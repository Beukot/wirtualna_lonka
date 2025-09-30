using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wirtualna_lonka.classes
{
    internal abstract class Organism
    {
        Position Pos;
        int Age;
        int Health;
        int Initiative;
        int Strength;
        int Agility;
        int Id;
        int MatingChance;
        
        void Action() { }
        void Mutation() { }
        void Mating() { }
    }
}
