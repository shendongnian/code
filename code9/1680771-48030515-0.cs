    try
    {
        await _queueClient
            .SendAsync(new Message(Encoding.UTF8.GetBytes("hello world")))
            .ContinueWith(t =>
            {
                Console.WriteLine(t.Status + "," + t.IsFaulted + "," + t.Exception.InnerException);
            }, TaskContinuationOptions.OnlyOnFaulted);
        Console.WriteLine("Done");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
