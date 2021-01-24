    static void LaunchTaskPool()
    {
        SemaphoreSlim maxThreadSemaphore = new SemaphoreSlim(2); //Max 2 tasks at a time.
        for (int i = 0; i < 5; i++)                     //loop through 5 tasks to be assigned
        {
            maxThreadSemaphore.Wait();                  //Wait for the queue
            Console.WriteLine("Assigning work {0} ", i);
            StartThead(i, maxThreadSemaphore);
        }
    }
    static void StartThead(int i, SemaphoreSlim maxThreadSemaphore)
    {
        Task.Factory.StartNew(
            () => DoWork(i.ToString()),
            TaskCreationOptions.None
        ).ContinueWith((task) => maxThreadSemaphore.Release());
    }
    static void DoWork(string workname)
    {
        Thread.Sleep(100);
        Console.WriteLine("--work {0} starts", workname);
        Thread.Sleep(1000);
        Console.WriteLine("--work  {0} finishes", workname);
    }
