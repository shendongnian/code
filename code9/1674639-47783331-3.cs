    namespace ConsoleApplication1
    {
        public static class Program
        {
            public static void Main(String[] args)
            {
                flagTest.test T = new flagTest.test();
                T.Start();
                while (true)
                {
                    String command = Console.ReadLine();
                    if (command.ToLowerInvariant() == "stop")
                    {
                        T.Stop();
                        break;
                    }
                }
                
                Console.ReadLine();
            }
        }
    }
