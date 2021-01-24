    class Program
        {
            static void Main(string[] args)
            {
                if (args.Length > 0)
                {
                    Console.WriteLine(args[0]);  // <-- args[0] contains filename
                }
                Console.ReadLine();
            }
        }
