    public Task JoeAsync()
    {
        return Task.CompletedTask;
    }
    
    public Task JimAsync()
    {
        return Task.FromException(new NullReferenceException("Fake null reference"));
    }
    
    // Make sure cancelToken.IsCancellationRequested == true
    public Task JoeAsync(CancellationToken cancellationToken)
    {
        return Task.FromCanceled(cancellationToken);
    }
    
    public Task<string> JanAsync()
    {
        return Task.FromResult("Should complete successfully");
    }
    
    public Task<string> JedAsync()
    {
        return Task.FromException<string>(new NullReferenceException("Fake null reference"));
    }
    
    // Make sure cancelToken.IsCancellationRequested == true
    public Task<string> JanAsync(CancellationToken cancellationToken)
    {
        return Task.FromCanceled<string>(cancellationToken);
    }
