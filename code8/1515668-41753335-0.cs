    public class Monitor
    {
        private TaskCompletionSource<bool> _changedTaskSource = new TaskCompletionSource<bool>();
        public Task HasChangedTask => _changedTaskSource.Task;
    
        public bool HasChanged
        ...
        set
        {
            ...
            _changedTaskSource.TrySetResult(true);
        }
    }
