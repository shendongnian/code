    abstract public void Open();
 
    public Task OpenAsync() {
        return OpenAsync(CancellationToken.None);
    }
 
    public virtual Task OpenAsync(CancellationToken cancellationToken) {
        TaskCompletionSource<object> taskCompletionSource = new TaskCompletionSource<object>();
 
        if (cancellationToken.IsCancellationRequested) {
            taskCompletionSource.SetCanceled();
        }
        else {
            try {
                Open();
                taskCompletionSource.SetResult(null);
            }
            catch (Exception e) {
                taskCompletionSource.SetException(e);
            }
        }
 
        return taskCompletionSource.Task;
    }
