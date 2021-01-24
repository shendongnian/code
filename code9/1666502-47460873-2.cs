    static void Main(string[] args)
    {
        Console.WriteLine($"Starting test program (ManagedThreadId={Thread.CurrentThread.ManagedThreadId} IsThreadPoolThread={Thread.CurrentThread.IsThreadPoolThread})");
        SerialTaskQueue co_pQueue = new SerialTaskQueue();
        for (int i = 0; i < 2; i++)
        {
            var local = i;
            co_pQueue.Enqueue(() => Task.Factory.StartNew(() => { return SimulateTaskSequence(local); }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default).Unwrap());
        }
    }
