    class Program
    {
        static void Main(string[] args)
        {
            List<Driver> driversFirstTable = new List<Driver>()
            {
                new Driver
                {
                    DriverName = "John", DriverRaces = new Collection<DriverRace>
                    {
                        new DriverRace { Points = 99, Category = "Rookie" },
                        new DriverRace { Points = 100, Category = "Rookie" },
                        new DriverRace { Points = 10, Category = "Mid" },
                        new DriverRace { Points = 99, Category = "Pro" },
                    }
                },
                new Driver
                {
                    DriverName = "Jack", DriverRaces = new Collection<DriverRace>
                    {
                        new DriverRace { Points = 100, Category = "Rookie" },
                        new DriverRace { Points = 98, Category = "Rookie" },
                        new DriverRace { Points = 66, Category = "Mid" },
                        new DriverRace { Points = 100, Category = "Pro" },
                    }
                },
                new Driver
                {
                    DriverName = "Richard", DriverRaces = new Collection<DriverRace>
                    {
                        new DriverRace { Points = 98, Category = "Rookie" },
                        new DriverRace { Points = 99, Category = "Rookie" },
                        new DriverRace { Points = 62, Category = "Mid" },
                        new DriverRace { Points = 98, Category = "Pro" },
                    }
                },
                new Driver
                {
                    DriverName = "Will", DriverRaces = new Collection<DriverRace>
                    {
                        new DriverRace { Points = 97, Category = "Rookie" },
                        new DriverRace { Points = 97, Category = "Rookie" },
                        new DriverRace { Points = 61, Category = "Mid" },
                        new DriverRace { Points = 97, Category = "Pro" },
                    }
                }
            };
            var rookieTop = driversFirstTable
                .Select(x => new DriverAggregated { Category = "Rookie", DriverName = x.DriverName, TotalPoints = x.DriverRaces.Where(y => y.Category == "Rookie").Sum(y => y.Points) })
                .OrderByDescending(x => x.TotalPoints)
                .Take(3);
            // Will is not in the list
            foreach (var driver in rookieTop)
            {
                Console.WriteLine($"Driver - {driver.DriverName} gathered {driver.TotalPoints} points.");
            }
            Console.Read();
        }
    }
    class DriverAggregated
    {
        public string DriverName { get; set; }
        public int TotalPoints { get; set; }
        public string Category { get; set; }
    }
    public class Driver
    {
        public string DriverName { get; set; }
        public virtual ICollection<DriverRace> DriverRaces { get; set; }
    }
    public class DriverRace
    {
        public int Points { get; set; }
        public string Category { get; set; }
    }
