    while (token.IsCancellationRequested == false)
    {
        Console.Write("*");
        Thread.Sleep(1000);
    }
    token.ThrowIfCancellationRequested();
