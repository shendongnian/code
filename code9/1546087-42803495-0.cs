    class Program
    {
        private static int ConcurrentActions = 0;
        public static void Main()
        {
            var actionBlock = new ActionBlock<string>(new Action<string>(Execute), new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 10 });
                
            for (int i = 0; i < 20; i++)
            {
                actionBlock.Post(i.ToString());
            }
            actionBlock.Complete();
            while (!actionBlock.Completion.IsCompleted)
            {
                Console.WriteLine("Concurrent actions: {0}", ConcurrentActions);
                Thread.Sleep(200);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        private static void Execute(string url)
        {
            Interlocked.Increment(ref ConcurrentActions);
            Thread.Sleep(1000); // Workload
            Interlocked.Decrement(ref ConcurrentActions);
        }
    }
