    public Task<int> DoSomethingAsync(CancellationToken cancellationToken)  
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<int>(cancellationToken);
        }
    
        try
        {
            return Task.FromResult<int>(DoSomething());
        }
        catch (Exception e)
        {
            return Task.FromException<int>(e);
        }
    }
