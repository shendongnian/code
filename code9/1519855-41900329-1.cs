    CancellationTokenSource cts = new CancellationTokenSource();
    
    var task1 = Func1Async(cts.Token);
    task1.ContinueWith(task => cts.Cancel(), cts.Token, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    var task2 = Func2Async(cts.Token);
    task2.ContinueWith(task => cts.Cancel(), cts.Token, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    var task3 = Func3Async(cts.Token);
    task3.ContinueWith(task => cts.Cancel(), cts.Token, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
    
    await Task.WhenAll(task1, task2, task3);
