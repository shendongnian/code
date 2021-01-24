    var buffer = new byte[1];
    Console.WriteLine("Waiting for input");
    while (!Console.KeyAvailable && !cancellationSource.Token.IsCancellationRequested)
        await Task.Delay(10); // You can add the cancellation token as a second parameter here, but then canceling it will cause .Delay to throw an exception
    if (cancellationSource.Token.IsCancellationRequested)
    {
        Console.WriteLine("Canceled; no longer waiting for input");
    }
    else
    {
        await input.ReadAsync(buffer, 0, 1);
        Console.WriteLine("Got user input");
    }
