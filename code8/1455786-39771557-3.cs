    private static void Main(string[] args)
    {
            var bar = new Bar();
            // here you define the name of new variable ("b")
            var foo = new Foo(bar, "b");
            string input = Console.ReadLine();
            
            while (!string.IsNullOrEmpty(input))
            {
                Console.WriteLine(foo.Evaluate(input));
                input = Console.ReadLine();
            }
            Console.WriteLine("Press any key to quit");
            Console.Read();
    }
