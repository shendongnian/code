    class Crate : IEnumerable<Beverage>
    {
        private readonly List<Beverage> crate = new List<Beverage>();
        private const int MaxItems = 24;
        private static readonly Random Rnd = new Random();
        public void Add(Beverage beverage)
        {
            if (crate.Count >= MaxItems)
            {
                Console.WriteLine("The crate is full. Please remove an item first!");
            }
            else
            {
                crate.Add(beverage);
            }
        }
        public void Remove(string name)
        {
            Remove(crate.FirstOrDefault(i =>
                i.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }
        public void Remove(Beverage beverage)
        {
            if (crate.Contains(beverage)) crate.Remove(beverage);
        }
        public void PrintBeverages()
        {
            if (crate.Count == 0)
            {
                Console.WriteLine("There are no items in the crate.");
            }
            else
            {
                crate.ForEach(Console.WriteLine);
            }
        }
        public IEnumerator<Beverage> GetEnumerator()
        {
            return crate.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public static Beverage GetBeverageFromUser()
        {
            return new Beverage
            {
                Name = GetString("Enter name: "),
                Price = GetDecimal("Enter cost: "),
                Type = GetBeverageType("Enter type: ")
            };
        }
        public static Beverage GetRandomBeverage()
        {
            var names = new List<Beverage>
            {
                new Beverage {Name = "Coke", Price = .75m,
                    Size = 12, Type = BeverageType.Soda},
                new Beverage {Name = "Pepsi", Price = .75m,
                    Size = 12, Type = BeverageType.Soda},
                new Beverage {Name = "Sprite", Price = .75m,
                    Size = 12, Type = BeverageType.Soda},
                new Beverage {Name = "Rootbeer", Price = .75m,
                    Size = 12, Type = BeverageType.Soda},
                new Beverage {Name = "Orange Juice", Price = .5m,
                    Size = 10, Type = BeverageType.Juice},
                new Beverage {Name = "Apple Juice", Price = .5m,
                    Size = 10, Type = BeverageType.Juice},
                new Beverage {Name = "Grape Juice", Price = .5m,
                    Size = 10, Type = BeverageType.Juice},
                new Beverage {Name = "Water", Price = .25m,
                    Size = 20, Type = BeverageType.Water},
                new Beverage {Name = "Beer", Price = 2.75m,
                    Size = 16, Type = BeverageType.Alcohol},
                new Beverage {Name = "Wine", Price = 3.5m,
                    Size = 9, Type = BeverageType.Alcohol},
            };
            
            return names[Rnd.Next(names.Count)];
        }
        private static BeverageType GetBeverageType(string message)
        {
            BeverageType beverageType;
            Console.WriteLine(message);
            while (!Enum.TryParse(Console.ReadLine(), true, out beverageType))
            {
                Console.WriteLine("Invalid beverage type");
                Console.WriteLine("Valid beverage types are: {0}", 
                    string.Join(", ", Enum.GetValues(typeof(BeverageType))));
                Console.WriteLine(message);
            }
            return beverageType;
        }
        private static string GetString(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        private static decimal GetDecimal(string message)
        {
            decimal result;
            Console.WriteLine(message);
            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid number");
                Console.WriteLine(message);
            } 
            return result;
        }
    }
