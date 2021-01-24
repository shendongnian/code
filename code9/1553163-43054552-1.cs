    public class TaskDelayedCompletionSource
    {
        private TaskCompletionSource<bool> _completionSource;
        private readonly System.Timers.Timer _timer;
        private readonly object _lockObject = new object();
        public TaskDelayedCompletionSource(double interval)
        {
            _completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.DenyChildAttach | TaskCreationOptions.RunContinuationsAsynchronously);
            _timer = new Timer(interval);
            _timer.AutoReset = false;
            _timer.Elapsed += OnTimerOnElapsed;
            _timer.Start();
        }
        private void OnTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            //Cache a copy of the completion source before we entier the lock, so we don't complete the wrong source if ResetDelay is in the middle of being called.
            var completionSource = _completionSource;
            lock (_lockObject)
            {
                completionSource.TrySetResult(true);
            }
        }
        public void ResetDelay(double interval)
        {
            lock (_lockObject)
            {
                var oldSource = _completionSource;
                _timer.Interval = interval;
                _completionSource = new TaskCompletionSource<bool>();
                oldSource.TrySetCanceled();
            }
        }
        public Task Task => _completionSource.Task;
    }
