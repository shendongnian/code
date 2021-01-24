    static int _outstandingOperations;
    static readonly object _lock = new object();
    static void Main() {
        for (int i = 0; i < 100; i++) {
            var tmp = i;
            Task.Run(() =>
            {
                lock (_lock) {
                    _outstandingOperations++;
                }
                // some work
                Thread.Sleep(new Random(tmp).Next(0, 5000));
                lock (_lock) {
                    _outstandingOperations--;
                    // notify condition might have changed
                    Monitor.Pulse(_lock);
                }
            });
        }
        lock (_lock) {
            // condition check
            while (_outstandingOperations > 0)
                // will wait here until pulsed, lock will be released during wait
                Monitor.Wait(_lock);
        }
    }
