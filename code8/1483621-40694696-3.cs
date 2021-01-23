    public Task<int> SomeMethodAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<int>(cancellationToken);
        }
        
        try { return Task.FromResult(SomeMethod()); }
        catch (OperationCanceledException oce)
        {
            var canceledTaskBuilder = new TaskCompletionSource<int>();
            canceledTaskBuilder.SetCanceled();
            return canceledTaskBuilder.Task;
        }
        catch (Exception e)
        {
            return Task.FromException<int>(e);
        }
    }
