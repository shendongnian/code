    public async Task JoeAsync()
    {
        await Task.CompletedTask;
    }
    public async Task JimAsync()
    {
        await Task.FromException(new NullReferenceException("Fake null reference"));
    }
    // Make sure cancelToken.IsCancellationRequested == true
    public async Task JoeAsync(CancellationToken cancellationToken)
    {
        await Task.FromCanceled(cancellationToken);
    }
    public async Task<string> JanAsync()
    {
        return await Task.FromResult("Should complete successfully");
    }
    public async Task<string> JedAsync()
    {
        return await Task.FromException<string>(new NullReferenceException("Fake null reference"));
    }
    // Make sure cancelToken.IsCancellationRequested == true
    public async Task<string> JanAsync(CancellationToken cancellationToken)
    {
        return await Task.FromCanceled<string>(cancellationToken);
    }
