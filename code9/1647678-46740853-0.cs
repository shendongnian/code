            var t = new List<int>()
                {2,2,2,1,1,1,1,1,1,1,
                 1,1,1,1,1,3,1,1,1,1,
                 1,1,1,1,1,1,1,1,5,4,
                 26,12,11,16,44,4,37,26,13,36};
            int activeCount = 0;
            int remaining = t.Count;
            var cq = new ConcurrentQueue<int>(t);
            var tasks = new List<Task>();
            for (int i = 0; i < 4; i++) tasks.Add(Task.Factory.StartNew(() => 
            {
                int x;
                while (cq.TryDequeue(out x))
                {
                    Console.WriteLine($"Active={Interlocked.Increment(ref activeCount)} " +
                        $"Remaining={Interlocked.Decrement(ref remaining)} " +
                        $"Run thread={Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(x * 1000); //Sleep x seconds
                    Interlocked.Decrement(ref activeCount);
                }
            }));
            Task.WaitAll(tasks.ToArray());
 
