    private CancellationTokenSource cts = new CancellationTokenSource();
    private async Task DoWork()
    {
        cts = new CancellationTokenSource();
        try
        {
            await Task.Delay(3000, cts.Token);
        }
        catch(TaskCanceledException)
        {
            return;
        }
        ...
    }
    
    private void Event()
    {
        cts.Cancel();
        Task.Run(() => DoWork());
    }
