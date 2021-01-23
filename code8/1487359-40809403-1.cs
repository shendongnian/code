    class TestClass
    {
        static void Main(string[] args)
        {
            // Display the number of command line arguments:
            System.Console.WriteLine(args.Length);
            foreach(var arg in args)
            {
                System.Console.WriteLine(arg);
            }
        }
    }
