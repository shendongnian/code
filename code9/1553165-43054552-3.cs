    public class TaskDelayedCompletionSource
    {
        private TaskCompletionSource<bool> _completionSource;
        private readonly System.Threading.Timer _timer;
        private readonly object _lockObject = new object();
        public TaskDelayedCompletionSource(int interval)
        {
            _completionSource = CreateCompletionSource();
            _timer = new Timer(OnTimerCallback);
            _timer.Change(interval, Timeout.Infinite);
        }
        private static TaskCompletionSource<bool> CreateCompletionSource()
        {
            return new TaskCompletionSource<bool>(TaskCreationOptions.DenyChildAttach | TaskCreationOptions.RunContinuationsAsynchronously | TaskCreationOptions.HideScheduler);
        }
        private void OnTimerCallback(object state)
        {
            //Cache a copy of the completion source before we entier the lock, so we don't complete the wrong source if ResetDelay is in the middle of being called.
            var completionSource = _completionSource;
            lock (_lockObject)
            {
                completionSource.TrySetResult(true);
            }
        }
        public void ResetDelay(int interval)
        {
            lock (_lockObject)
            {
                var oldSource = _completionSource;
                _timer.Change(interval, Timeout.Infinite);
                _completionSource = CreateCompletionSource();
                oldSource.TrySetCanceled();
            }
        }
        public Task Task => _completionSource.Task;
    }
