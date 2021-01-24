    class Car
    {
        public string Id;
        public string Name;
        public override string ToString()
        {
            return String.Concat(Id, Name);
        }
    }
    public static class Helper
    {
        public static void WriteToConsole<T>(this IList<T> collection)
        {
            Console.WriteLine(string.Join("\t", collection.ToArray()));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car() { Id = "1", Name = "Polonez Caro" });
    
            Helper.WriteToConsole(cars);
            Console.ReadKey();
        }
    }
