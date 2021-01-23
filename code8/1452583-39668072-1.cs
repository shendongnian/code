    private Task _serviceTask;
    public void Start()
    {
        _serviceTask = ExecuteAsync();
    }
    public void Stop()
    {
        _canceller.Cancel();
        _serviceTask.Wait();
    }
    public Task ExecuteAsync()
    {
        await Init();
        while (!_canceller.Token.IsCancellationRequested)
        {
            await Poll();
        }
    }
