    var parentTask = Task.Factory.StartNew(() =>
    {
        Task.Factory.StartNew(() => Thread.Sleep(1000)).Wait();       
        Console.WriteLine("parent task completed");
    });
