using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wirtualna_lonka.classes.animals;
using wirtualna_lonka.classes.plants;

namespace wirtualna_lonka.classes
{
    internal class World
    {
        private static World _instance;
        private List<Organism> organisms = new List<Organism>();

        private World()
        {
        }

        public int WorldSize { get; set; }

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

        public void SpawnInititalOrganisms()
        {
            for (int i = 0; i < WorldSize; i++)
            {
                Organism organism = null;

                switch (rng.Next(0, 2))
                {
                    case 0:
                        organism = new Sheep();
                        break;
                    case 1:
                        organism = new Grass();
                        break;
                }

                List<Organism> orgs = GetOrganisms();
                bool legalPos = false;
                Position pos = RandomPosition();

                while (legalPos == false)
                {
                    pos = RandomPosition();
                    bool illegalPos = false;

                    foreach (Organism org in orgs)
                    {
                        if (org.Compare(pos))
                        {
                            illegalPos = true;
                        }
                    }

                    if (!illegalPos)
                    {
                        legalPos = true;
                    }
                }

                organism.Position = pos;
                this.AddOrganism(organism);

            }
        }
    }
}