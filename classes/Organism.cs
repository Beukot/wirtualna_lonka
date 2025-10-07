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
        protected string name { get; set; }
        public Position Position { get; set; }
        protected int age { get; set; }
        protected double health { get; set; }
        protected double initiative { get; set; }
        protected double strenght { get; set; }
        protected double agility { get; set; }
        int id { get; set; }
        protected double multiplyChance { get; set; }
        static int id_counter { get; set; }
        public BitmapImage image { get; set; }
        protected int spawnRate { get; set; }
        protected static Random r = new Random();

        public Organism(double health, double initiative, double strenght, double agility, double multiplyChance, string imageSource)
        {
            this.image = new BitmapImage(new Uri(imageSource, UriKind.Relative));
            this.id = id_counter++;
            this.health = health;
            this.initiative = initiative;
            this.strenght = strenght;
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