    private const int RequestTimeoutInMilliseconds = 10000;
    
    public async Task<T> ExecuteTask<T>(Task<T> task)
    {
        if (await Task.WhenAny(task, Task.Delay(RequestTimeoutInMilliseconds)).ConfigureAwait(false) == task)
        {
            return task.Result;
        }
    
        throw new OperationCanceledException(typeof(T) + " Task failed");
    }
