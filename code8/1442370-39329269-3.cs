    public class MultiIntervalTimerCallbackInfo
    {
        public MultiIntervalTimerCallbackInfo(TimerCallback callback, object state)
        {
            if (callback == null)
                throw new ArgumentNullException(nameof(callback));
            Callback = callback;
            State = state;
        }
        public TimerCallback Callback { get; }
        public object State { get; }
    }
    public class MultiIntervalTimer: IDisposable
    {
        private readonly Timer innerTimer;
        private readonly Dictionary<int, MultiIntervalTimerCallbackInfo> callbacks;
        private long elapsedMiliseconds;
        private readonly int interval;
        private object syncRoot = new object();
        private bool disposed;
        public MultiIntervalTimer(Dictionary<int, MultiIntervalTimerCallbackInfo> callbacks, int dueTime)
        {
            if (callbacks == null)
                throw new ArgumentNullException(nameof(callbacks));
            if (callbacks.Keys.Any(k => k < 1))
                throw new ArgumentException("Intervals can not be 0 or smaller.");
            var innerTimerCallback = new TimerCallback(innerCallback);
            this.callbacks = new Dictionary<int, MultiIntervalTimerCallbackInfo>(callbacks);
            interval = getGreatestCommonDivisor(callbacks.Keys.ToArray());
            innerTimer = new Timer(innerTimerCallback, null, dueTime, interval);
        }
        public void Dispose()
        {
            if (disposed)
                return;
            innerTimer.Dispose();
            disposed = true;
        }
        private static int getGreatestCommonDivisor(int[] numbers)
        {
            if (numbers.Length == 1)
                return numbers[0];
            if (numbers.Length == 2)
                return getGreatestCommonDivisor(numbers[0], numbers[1]);
            return getGreatestCommonDivisor(numbers[0], getGreatestCommonDivisor(numbers.Skip(1).ToArray()));
        }
        private static int getGreatestCommonDivisor(int left, int right)
        {
            while (right != 0)
            {
                var temp = right;
                right = left % right;
                left = temp;
            }
            return left;
        }
        private void innerCallback(object state)
        {
            var elapsed = 0L;
            lock (syncRoot)
            {
                elapsedMiliseconds += interval;
                elapsed = elapsedMiliseconds;
            }
            foreach (var callback in callbacks.Where(c => elapsed % c.Key == 0))
            {
                callback.Value?.Callback(callback.Value.State);
            }
        }
    }
