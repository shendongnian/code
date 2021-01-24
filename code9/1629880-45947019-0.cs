    return Task.Run(() =>
    {
        token.ThrowIfCancellationRequested();
        Console.WriteLine("1st"); 
        Thread.Sleep(1000);
        token.ThrowIfCancellationRequested();
        Console.WriteLine("2nd");
        Thread.Sleep(1000);
        token.ThrowIfCancellationRequested();
        Console.WriteLine("3rd");
        Thread.Sleep(1000);
        token.ThrowIfCancellationRequested();
        Console.WriteLine("4th");
        Thread.Sleep(1000);
        token.ThrowIfCancellationRequested();
        Console.WriteLine("[Completed]");
    }, token); 
