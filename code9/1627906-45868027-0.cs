    Random rnd = new Random();
    int maxConcurrency = 5;
    var _workTaskQueue = new System.Collections.Concurrent.BlockingCollection<Task>();
    for (int i = 0; i < 250; i++) 
    {
        //Tasks running 250=500ms
        _workTaskQueue.Add(new Task(()=> { Task.Delay(250 + rnd.Next(250)).Wait(); }));
    } 
    _workTaskQueue.CompleteAdding();
    int runningTaks = 0;
    using (SemaphoreSlim concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
    {
        foreach (var task in _workTaskQueue.GetConsumingEnumerable())
        {
            Console.WriteLine("LoopStart: " + runningTaks);
            await concurrencySemaphore.WaitAsync();
            Console.WriteLine("GotASem  : " + runningTaks);
            task.Start(); 
            Interlocked.Increment(ref runningTaks);
            task.ContinueWith(t =>
                {
                    Interlocked.Decrement(ref runningTaks);
                    concurrencySemaphore.Release();
                });
            if (runningTaks > maxConcurrency) throw new Exception("ERROR");
            Console.WriteLine("LoopEnd  : " + runningTaks + Environment.NewLine);
        }
        Console.WriteLine("Finalizing: " + runningTaks);
        //Make sure all all tasks have ended.
        for (int i = 0; i < maxConcurrency; i++)
        {
            await concurrencySemaphore.WaitAsync();
        }
        Console.WriteLine("Finished: " + runningTaks);
    }
