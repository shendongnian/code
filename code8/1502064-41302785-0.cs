    public async Task StopAsync()
    {
        tokenSource.Cancel();
        await Task.WhenAll(Tasks.ToArray());
        Console.WriteLine("all finished");
        Start();
    }
    await StopAsync();
    //now all tasks have been stopped...do something
