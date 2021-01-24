    Task t1 = Task.Run(() =>
    {
        throw null;       
    });
    Task t2 = Task.Run(async () =>
    {
        // check whether task 1 is finished yet 
        while (!t1.IsCompleted) await Task.Delay(10);
        if (t1.Status == TaskStatus.RanToCompletion)
        {
            // we know that t1 finished successfully and did not throw any 
            // error.           
        }
        else
        {
            Console.WriteLine("We know that t1 did not run to completion");
        }
    });
    try
    {
        Task.WaitAll(t1, t2); 
        // this will now throw the exception from t1 because t2 can also finish
    }
    catch (AggregateException)
    {
    }
    
    // For interest sake, you can now view the status of each task.            
    Console.WriteLine(t1.Status);
    Console.WriteLine(t2.Status);
    Console.WriteLine("Finished");
    
