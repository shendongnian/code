    public void Start()
    {
        StartAsync().Wait();
    }
    public Task StartAsync()
    {
        await Init();
        while (!_canceller.Token.IsCancellationRequested)
        {
            await Poll();
        }
    }
