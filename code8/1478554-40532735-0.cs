    private TaskCompletionSource<Output> tcs;
    
    public Task<Output> GetOutputs(string id)
    {    
        tcs = new TaskCompletionSource<Output>();
    
        ConfigurationManager cm = new ConfigurationManager();
        cm.GetOutputResult += OnGetOutputResult;    
        cm.GetOutputAsync(id);
    
        // this will be the task that will complete once tcs.SetResult or similar has been called
        return tcs.Task;
    }
    
    private void OnGetOutputResult(Output output)
    {
        if (tcs == null) {
            throw new FatalException("TaskCompletionSource wasn't instantiated before it was called");
        }
        // tcs calls here will signal back to the task that something has happened.
        if (output == null) {
           // demoing some functionality
           // we can set exceptions
           tcs.SetException(new NullReferenceException());
           return;
        }
    
        // or if we're happy with the result we can send if back and finish the task
        tcs.SetResult(output);
    }
