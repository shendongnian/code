    SemaphoreSlim maxThreadSemaphore = new SemaphoreSlim(2); //Max 2 tasks at a time.
    for (int i = 0; i < 5; i++)                     //loop through 5 tasks to be assigned
    {
        maxThreadSemaphore.Wait();                  //Wait for the queue
        Console.WriteLine("Assigning work {0} ", i);
        int copy = i;
        Task t = Task.Factory.StartNew(() =>
                {
                    DoWork(copy.ToString());                   // assign tasks
                }, TaskCreationOptions.LongRunning
            )
            .ContinueWith(
                (task) => maxThreadSemaphore.Release()  // step out of the queue
            );
    }
