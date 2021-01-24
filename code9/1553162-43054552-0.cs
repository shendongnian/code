    public class TaskDelayedCompletionSource
    {
        private readonly TaskCompletionSource<bool> _completionSource;
        private readonly System.Timers.Timer _timer;
        public TaskDelayedCompletionSource(double interval)
        {
            _completionSource = new TaskCompletionSource<bool>();
            _timer = new Timer(interval);
            _timer.AutoReset = false;
            _timer.Elapsed += (sender, e) => _completionSource.SetResult(true);
            _timer.Start();
        }
        public void ResetDelay(double interval) => _timer.Interval = interval;
        public Task Task => _completionSource.Task;
    }
