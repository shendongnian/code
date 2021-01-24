    void Main()
    {
        CancellationTokenSource cts = new CancellationTokenSource(new TimeSpan(0,0,0,0,1000));
    
        Task t = Task.Run(() => Work(cts.Token),cts.Token);
        try
        {
            t.Wait();
        }
        catch
        {
        }
    
        ("Completed :: " + t.IsCompleted).Dump();
        ("Canceled :: " + t.IsCanceled).Dump();
        ("Faulted :: " + t.IsFaulted).Dump();
    }
    
    public async Task Work(CancellationToken token)
    {
        await Task.Delay(3000, token);
    }
