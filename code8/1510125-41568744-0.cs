    public Task<string> TestMethod()
    {
        TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
         //your code Here
        return tcs.Task;
    }
