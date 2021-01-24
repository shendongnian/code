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
                Price = GetCurrency("Enter cost: "),
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
            Console.Write(message);
            while (!Enum.TryParse(Console.ReadLine(), true, out beverageType))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid beverage type");
                Console.ResetColor();
                Console.Write("Valid beverage types are: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Join(", ", Enum.GetNames(typeof(BeverageType))));
                Console.ResetColor();
                Console.Write(message);
            }
            return beverageType;
        }
        private static string GetString(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }
        private static decimal GetCurrency(string message)
        {
            decimal result;
            Console.Write(message);
            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, 
                CultureInfo.CurrentCulture, out result))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid number");
                Console.ResetColor();
                Console.Write(message);
            }
            return result;
        }
    }
