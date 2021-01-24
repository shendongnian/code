    class Program
    {
    static void Main(string[] args)
        {
            var productService = SingletonFactory.GetSingletoneInstance<ProductService>();
            var personService = SingletonFactory.GetSingletoneInstance<PersonService>();
            Console.ReadKey();
        }
    }
