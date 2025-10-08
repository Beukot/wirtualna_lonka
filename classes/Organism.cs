using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace wirtualna_lonka.classes
{
    public abstract class Organism
    {
        public string name { get; set; }
        public Position Position { get; set; }
        public int age { get; set; }
        public double health { get; set; }
        public double initiative { get; set; }
        public double strength { get; set; }
        public double agility { get; set; }
        public int id { get; set; }
        public double multiplyChance { get; set; }
        static int id_counter { get; set; }
        public BitmapImage image { get; set; }
        public int spawnRate { get; set; }
        protected static Random r = new Random();

        public Organism(double health, double initiative, double strength, double agility, double multiplyChance, string imageSource)
        {
            this.image = new BitmapImage(new Uri(imageSource, UriKind.Relative));
            this.id = id_counter++;
            this.health = health;
            this.initiative = initiative;
            this.strength = strength;
            this.agility = agility;
            this.multiplyChance = multiplyChance;
        }
        

        public abstract void Action();
        public abstract Organism Mutation();
        public abstract void Multiply();

        public bool Compare(Position pos)
        {
            return this.Position.Equals(pos);
        }

        public void addHealth(double health)
        {
            this.health += health;
        }

        public void Die(string cause)
        {
        }
    }
}