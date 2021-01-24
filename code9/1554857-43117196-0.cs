    Task timeout = new Task(() => Thread.Sleep(5000));
    Task worker = new Task(() => Thread.Sleep(6000)); // do main work
    
    worker.Start();
    timeout.Start();
    
    Task.WaitAny(worker, timeout);
    
    if(!worker.IsCompleted)
    {
         Console.WriteLine("Timeout!!");
    }
    else
    {
         Console.WriteLine("Finished!");
    }
