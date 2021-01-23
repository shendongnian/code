    private Task _serviceTask;
    public void Start()
    {
        Init().Wait();
        _serviceTask = ExecuteAsync();
    }
    public void Stop()
    {
        _canceller.Cancel();
        _serviceTask.Wait();
    }
    public Task ExecuteAsync()
    {
        while (!_canceller.Token.IsCancellationRequested)
        {
            await Poll();
        }
    }
