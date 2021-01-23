    public void Start()
    {
        StartAsync().Wait();
    }
    public async Task StartAsync()
    {
        await Init();
        while (!_canceller.Token.IsCancellationRequested)
        {
            await Poll();
        }
    }
