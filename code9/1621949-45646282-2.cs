    public abstract class AwaitableViewModelBase : ViewModelBase
    {
        protected TaskCompletionSource<bool> TaskCompletionSource { get; set; }
        public Task<bool> Task => TaskCompletionSource?.Task;
        public void RegisterTaskCompletionSource(TaskCompletionSource<bool> tcs)
        {
            var current = TaskCompletionSource;
            if (current != null && current.Task.Status == TaskStatus.Running)
                throw new InvalidOperationException();
            TaskCompletionSource = tcs;
        }
        public virtual void Cancel() => SetResult(false);
        protected void SetResult(bool result) => TaskCompletionSource?.TrySetResult(result);
    }
