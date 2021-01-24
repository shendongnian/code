        static void Main(string[] args)
        {
            string planetsDBStr = "1 Mercury Gray \n"
                    + "2 Venus Yellow \n"
                    + "3 Earth Blue \n"
                    + "4 Mars Red \n";
            List<Planet> planets = GetPlanetsFromDBString(planetsDBStr);
            foreach (Planet p in planets.OrderBy(x => x.color))
            {
                Console.WriteLine(p.ToString());
            }
            Console.ReadKey();
        }
        private static List<Planet> GetPlanetsFromDBString(string dbString)
        {
            List<Planet> retVal = new List<Planet>();
            string[] lines = dbString.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
                retVal.Add(new Planet(line));
            return retVal;
        }
        public class Planet
        {
            public int orderInSystem;
            public string name;
            public string color;
            public Planet(string databaseTextLine)
            {
                string[] parts = databaseTextLine.Split(' ');
                this.orderInSystem = int.Parse(parts[0]);
                this.name = parts[1];
                this.color = parts[2];
            }
            public override string ToString()
            {
                return orderInSystem + " " + name + " " + color;
            }
        }
