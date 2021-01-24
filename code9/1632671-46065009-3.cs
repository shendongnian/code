    var scheduler = NewThreadScheduler.Default;
    var enumerable = Enumerable.Range(0, 100);
    var xs = enumerable
        .ToObservable(scheduler)
        .SubscribeOn(scheduler);
    xs.Subscribe(item =>
    {
        Console.WriteLine("Slow consuming {0} on Thread: {1}",
            item, Thread.CurrentThread.ManagedThreadId);
        // simulate slower long running operation
        Thread.Sleep(1000);
    });
    xs.Subscribe(item =>
    {
        Console.WriteLine("Fast consuming {0} on Thread: {1}",
            item, Thread.CurrentThread.ManagedThreadId);
        // simulate faster long running operation
        Thread.Sleep(500);
    });
    Console.ReadKey();
