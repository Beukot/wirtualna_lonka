using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wirtualna_lonka.classes.animals;

namespace wirtualna_lonka.classes
{
    internal class World
    {
        private static World _instance;
        private List<Organism> organisms = new List<Organism>();

        private World() 
        {
        }

        public int WorldSize { get; set;}

        Random rng = new Random();

        public static World GetWorld(int worldSize)
        {
            if (_instance == null)
            {
                _instance = new World
                {
                    WorldSize = worldSize
                };
            }

            return _instance;
        }

        public void AddOrganism(Organism organism)
        {
            organisms.Add(organism);
        }

        public void RemoveOrganism(Organism organism)
        {
            organisms.Remove(organism);
        }

        public List<Organism> GetOrganisms()
        {
            return organisms;
        }

        public Position RandomPosition()
        {
            return new Position(rng.Next(0, WorldSize), rng.Next(0, WorldSize));
        }
    }
}
