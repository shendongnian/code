        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        private static readonly ConcurrentBag<int> Bag = new ConcurrentBag<int>();
        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(async () => await SampleTask());
            }
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                int item;
                if (Bag.TryTake(out item))
                    Console.WriteLine(item);
            }
        }
        private static async Task SampleTask()
        {
            await Task.Delay(Random.Next(1000));
            Bag.Add(Random.Next(10));
        }
