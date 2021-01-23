    public struct AwaitableDisposable<T> where T : IDisposable
    {
        private readonly Task<T> _task;
        public AwaitableDisposable(Task<T> task) { _task = task; }
        public TaskAwaiter<T> GetAwaiter() => _task.GetAwaiter();
        public ConfiguredTaskAwaitable<T> ConfigureAwait(bool continueOnCapturedContext) =>
            _task.ConfigureAwait(continueOnCapturedContext);
        public Task<T> AsTask() => _task;
        public static implicit operator Task<T>(AwaitableDisposable<T> source) =>
            source.AsTask();
    }
