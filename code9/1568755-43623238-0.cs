     class Program
        {
            static void procedure()
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Sleep");
                }
            }
            static Thread runner;
    
            static void Main(string[] args)
            {
                runner = new Thread(new ThreadStart(procedure));
                Console.WriteLine("Here!");
                runner.Start();
                Console.WriteLine("And now here...");
    
            }
        }
