    public class MultiIntervalTimer: IDisposable
    {
        private readonly Timer innerTimer;
        private readonly IReadOnlyDictionary<int, MultiIntervalTimerCallbackInfo> callbackInfos;
        private long totalElapsedMiliseconds;
        private readonly int innerTimerInterval;
        private object syncRoot = new object();
        private bool disposed;
        public MultiIntervalTimer(Dictionary<int, MultiIntervalTimerCallbackInfo> callbacks, int dueTime)
        {
            if (callbacks == null)
                throw new ArgumentNullException(nameof(callbacks));
            var innerTimerCallback = new TimerCallback(innerCallback);
            callbackInfos = new Dictionary<int, MultiIntervalTimerCallbackInfo>(callbacks);
            innerTimerInterval = getGreatestCommonDivisor(callbacks.Keys);
            innerTimer = new Timer(innerTimerCallback, null, dueTime, innerTimerInterval);
        }
        public void Dispose()
        {
            if (disposed)
                return;
            innerTimer.Dispose();
            disposed = true;
        }
        private static int getGreatestCommonDivisor(IEnumerable<int> numbers)
        {
            Debug.Assert(numbers != null);
            Debug.Assert(numbers.Any());
            var numbersArray = numbers.ToArray();
            if (numbersArray.Length == 1)
                return numbersArray[0];
            if (numbersArray.Length == 2)
                return getGreatestCommonDivisor(numbersArray[0], numbersArray[1]);
            var trimmedNumbersArray = new int[numbersArray.Length - 1];
            Array.Copy(numbersArray, 1, trimmedNumbersArray, 0, trimmedNumbersArray.Length);
            return getGreatestCommonDivisor(numbersArray[0], getGreatestCommonDivisor(trimmedNumbersArray));
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
            Debug.Assert(syncRoot != null);
            Debug.Assert(!disposed);
            var elapsed = 0L;
            lock (syncRoot)
            {
                totalElapsedMiliseconds += innerTimerInterval;
                elapsed = totalElapsedMiliseconds;
            }
            foreach (var callback in callbackInfos.Where(c => elapsed % c.Key == 0))
            {
                callback.Value?.Callback(callback.Value.State);
            }
        }
    }
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
