    public class Thing
    {
        public string Category { get; set; }
        public string Item { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foos = new List<Thing>
            {
                new Thing { Category = "Fruit", Item = "Apple" },
                new Thing { Category = "Fruit", Item = "Orange" },
                new Thing { Category = "Fruit", Item = "Banana" },
                new Thing { Category = "Vegetable", Item = "Potato" },
                new Thing { Category = "Vegetable", Item = "Carrot" }
            };
            var group = foos.GroupBy(f => f.Category).First();
            for (int i = 0; i < group.Count(); i++)
            {
                Console.WriteLine(group.ElementAt(i).Item); //works great
            }
        }
    }
