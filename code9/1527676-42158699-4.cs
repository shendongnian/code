    Task t = Task.Factory.StartNew(() =>
    {
        myResult = method();  // Request processing in parallel
        cts.Token.ThrowIfCancellationRequested(); // React on cancellation 
    }, cts.Token);
