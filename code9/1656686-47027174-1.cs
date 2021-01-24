    [Test]
    class Program
    {
        static void Main(string[] args)
        {
            var attribute = typeof(Program).GetCustomAttribute<TestAttribute>();
            attribute.Greet("Hello World");
            Console.ReadKey();
        }
    }
