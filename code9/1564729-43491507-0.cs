    try
    {
        await deviceClient.SendEventAsync(message);
        Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);
    }
    catch (AggregateException e)
    {
        Console.WriteLine("{0} > Error Sending message: {1}", DateTime.Now, messageString);
        Console.WriteLine("AggregateException: {0} ", e.Message);
    }
