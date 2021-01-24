    Object thisLock = new Object();
    int totalThreads = 3;
    Task[] tasks = new Task[totalThreads];
    for (int j = 0; j < totalThreads; j++)
    {
        // We're taking a reference of the value of `j`, 
        // this is because on each iteration, the value of `j` 
        // will change and cause issues in your threads.
        var jRef = j;
        
        tasks[jRef] = Task.Run(() =>
        {
            for (int k = 0; k < totalThreads; k++)
            {
                lock (thisLock)
                {
                    // Perform operations on shared resources
                }
            }
        });
    }
    
    Task.WaitAll(tasks);
