    public struct CaptureContextOnSuccessAwaiter : INotifyCompletion
    {
        private Task task;
        public CaptureContextOnSuccessAwaiter(Task task)
        {
            this.task = task;
        }
        public CaptureContextOnSuccessAwaiter GetAwaiter() { return this; }
        public void OnCompleted(Action continuation)
        {
            if (SynchronizationContext.Current != null)
            {
                task.ContinueWith(t => continuation(),
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
                task.ContinueWith(t => continuation(),
                    CancellationToken.None,
                    TaskContinuationOptions.NotOnRanToCompletion,
                    TaskScheduler.Default);
            }
            else
            {
                task.ContinueWith(t => continuation(),
                    CancellationToken.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);
            }
        }
        public void GetResult() { task.GetAwaiter().GetResult(); }
        public bool IsCompleted { get { return task.GetAwaiter().IsCompleted; } }
    }
    public struct CaptureContextOnSuccessAwaiter<T> : INotifyCompletion
    {
        private Task<T> task;
        public CaptureContextOnSuccessAwaiter(Task<T> task)
        {
            this.task = task;
        }
        public CaptureContextOnSuccessAwaiter<T> GetAwaiter() { return this; }
        public void OnCompleted(Action continuation)
        {
            if (SynchronizationContext.Current != null)
            {
                task.ContinueWith(t => continuation(),
                    CancellationToken.None,
                    TaskContinuationOptions.OnlyOnRanToCompletion,
                    TaskScheduler.FromCurrentSynchronizationContext());
                task.ContinueWith(t => continuation(),
                    CancellationToken.None,
                    TaskContinuationOptions.NotOnRanToCompletion,
                    TaskScheduler.Default);
            }
            else
            {
                task.ContinueWith(t => continuation(),
                    CancellationToken.None,
                    TaskContinuationOptions.None,
                    TaskScheduler.Default);
            }
        }
        public T GetResult() { return task.GetAwaiter().GetResult(); }
        public bool IsCompleted { get { return task.GetAwaiter().IsCompleted; } }
    }
