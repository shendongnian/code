    public class Animal
    {
        public string Name { get; set; }
    }
    public class Leopard : Animal
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>
            {
                new Leopard { Name = "Bob" },
                new Leopard { Name = "Jeff" },
                new Leopard { Name = "Bill" },
                new Leopard { Name = "Dave" }
            };
            Leopard[] leopardArray = new Leopard[animals.Count];
            animals.CopyTo(leopardArray, 0);
            Console.Write(leopardArray.Count());
        }
    }
