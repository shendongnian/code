    Task task;
    var cancellationTokenSource = new CancellationTokenSource();
    var cancelToken = cancellationTokenSource.Token;
    
    cancellationTokenSource.Cancel();
    task = this.JoeAsync();
    Trace.Assert(task.IsCompleted);
    Trace.Assert(task.IsCompletedSuccessfully);
    task = this.JoeAsync(cancelToken);
    Trace.Assert(task.IsCanceled);
    Trace.Assert(cancelToken.IsCancellationRequested);
    task = this.JimAsync();
    Trace.Assert(task.IsFaulted);
    
    Task<string> task2;
    
    task2 = this.JanAsync();
    Trace.Assert(task2.IsCompleted);
    Trace.Assert(task2.IsCompletedSuccessfully);
    task2 = this.JanAsync(cancelToken);
    Trace.Assert(task2.IsCanceled);
    Trace.Assert(cancelToken.IsCancellationRequested);
    task2 = this.JedAsync();
    Trace.Assert(task2.IsFaulted);
