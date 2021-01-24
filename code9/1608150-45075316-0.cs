    // A worker thread that will run an action and batchup items.
    public class WorkerThread<T> : IDisposable
    {
        private Thread _thread;
        private List<T> _workItems = new List<T>();
        private ManualResetEvent _terminating = new ManualResetEvent(false);
        private AutoResetEvent _hasItems = new AutoResetEvent(false);
        private DateTime _lastExceedMessageDisplayed = DateTime.MinValue;
        public WorkerThread(Action<T[]> action, int maxBatchSize = 16, int queueLengthWarning = 1000, double queueLengthExceedMessageTimeoutSeconds = 2, ThreadPriority threadPriority = ThreadPriority.Normal)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            if (maxBatchSize < 1)
                throw new ArgumentOutOfRangeException("maxBatchSize", "must be higher than 0");
            if (queueLengthWarning < 1)
                throw new ArgumentOutOfRangeException("queueLengthWarning", "must be higher than 0");
            _thread = new Thread(() =>
            {
                try
                {
                    var handles = new EventWaitHandle[] { _terminating, _hasItems };
                    while (true)
                    {
                        // wait if one of the handles is set.
                        int index = EventWaitHandle.WaitAny(handles);
                        // create copy of queue
                        T[] items;
                        int totalQueueLength;
                        lock (_workItems)
                        {
                            totalQueueLength = _workItems.Count;
                            items = _workItems.Take(maxBatchSize).ToArray();
                            _workItems.RemoveRange(0, items.Length);
                            if (totalQueueLength > items.Length)
                                _hasItems.Set();
                        }
                        if (items.Length > 0)
                        {
                            if ((totalQueueLength > queueLengthWarning)
                                && (_lastExceedMessageDisplayed.AddSeconds(queueLengthExceedMessageTimeoutSeconds) < DateTime.UtcNow))
                            {
                                var msg = "WorkerThread: Queue length exceed limit " + queueLengthWarning + " with " + totalQueueLength;
                                Trace.TraceWarning(msg);
                                _lastExceedMessageDisplayed = DateTime.UtcNow;
                            }
                        }
                        // check if the terminating is set and not actions are queued..
                        if (_terminating.WaitOne(0) && (items.Length == 0))
                            break;
                        action(items);
                    }
                }
                catch (Exception exception)
                {
                    var msg = exception.ToString();
                    Trace.TraceError(msg);
                }
            });
            _thread.IsBackground = true;
            _thread.Priority = threadPriority;
            _thread.Start();
        }
        public bool Add(T item)
        {
            // do not add new items when terminating
            if (_terminating.WaitOne(0))
                return false;
            lock (_workItems)
            {
                _workItems.Add(item);
                _hasItems.Set();
            }
            return true;
        }
        public bool AddRange(IEnumerable<T> items)
        {
            // do not add new items when terminating
            if (_terminating.WaitOne(0))
                return false;
            lock (_workItems)
            {
                _workItems.AddRange(items);
                _hasItems.Set();
            }
            return true;
        }
        public void Dispose()
        {
            _terminating.Set();
            _thread.Join();
        }
    }
