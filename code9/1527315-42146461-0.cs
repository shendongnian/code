    static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("A");
                    Thread.Sleep(1);
                }
            });
            for (int i = 0; i < 10; i++)
            {
                Console.Write("B");
                Thread.Sleep(1);
            }
            Console.ReadKey();
        }
