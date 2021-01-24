    class Program
    {
        static void Main(string[] args)
        {
            LiveStock[] animals = new LiveStock[5];
            animals[0] = new LiveStock { ID = 1, Name = "Cow", AmountOfMilk = 10 };
            animals[1] = new LiveStock { ID = 2, Name = "Goat", AmountOfMilk = 20 };
            animals[2] = new LiveStock { ID = 3, Name = "Cow", AmountOfMilk = 10 };
            animals[3] = new LiveStock { ID = 4, Name = "Goat", AmountOfMilk = 30 };
            animals[4] = new LiveStock { ID = 5, Name = "Cow", AmountOfMilk = 50 };
            Console.WriteLine("Max milk Cow: " + GetMax(animals, "Cow").ID);
            Console.WriteLine("Max milk Goat: " + GetMax(animals, "Goat").ID);
            Console.ReadLine();
        }
        public static LiveStock GetMax(LiveStock[] animals, string animalName)
        {
            List<LiveStock> list = new List<LiveStock>(animals);
            return list.Where(a => a.Name == animalName).OrderByDescending(a => a.AmountOfMilk).First();
        }
    }
    class LiveStock
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AmountOfMilk { get; set; }
    }
