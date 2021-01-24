       namespace myapp
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello!");
                Console.WriteLine("Type 'exit' to exit!");
                string line = Console.ReadLine();
                if (line == "exit")
                {
                    Environment.Exit(0);
                }
                else if (line == "copyright") {
                    Console.WriteLine("Copyright 2017 TIVJ-dev");
                }
            }
        }
    }
