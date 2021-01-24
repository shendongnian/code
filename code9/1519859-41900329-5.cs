    public static class ExtensionMethods
    {
        public Task CancelOnFaulted(this Task task, CancellationTokenSource cts)
        {
            task.ContinueWith(task => cts.Cancel(), cts.Token, taskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
            return task;
        }
    
        public Task<T> CancelOnFaulted<T>(this Task<T> task, CancellationTokenSource cts)
        {
            task.ContinueWith(task => cts.Cancel(), cts.Token, taskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
            return task;
        }
    }
