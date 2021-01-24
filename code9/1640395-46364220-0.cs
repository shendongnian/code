    static class Utilities
    {
        public static async Task DisposeDelayed(this FileSystemWatcher watcher, TimeSpan inactivePeriod, CancellationToken ct)
        {
            DateTime disposalTime = DateTime.Now + inactivePeriod;
            FileSystemEventHandler postponeTrigger = (s, e) => disposalTime = DateTime.Now + inactivePeriod;
            watcher.Created += postponeTrigger;
            watcher.Changed += postponeTrigger;
            // add here other event handlers you need to postpone the disposal
            try
            {
                await RunAtTimePoint(() => disposalTime, ct, watcher.Dispose).ConfigureAwait(false);
            }
            finally
            {
                // don't forget to unsubscribe from each event
                watcher.Created -= postponeTrigger;
                watcher.Changed -= postponeTrigger;
            }
        }
        // You can also use this method for other tasks if you need
        public static async Task RunAtTimePoint(Func<DateTime> execTimeProvider, CancellationToken token, Action action)
        {
            int delayTime;
            do
            {
                // first, calculate the time left until the execution
                DateTime execTime = execTimeProvider();
                TimeSpan timeLeft = execTime - DateTime.Now;
                // we delay in 1000 ms chunks;
                // but if the delay time is less, we need to handle that
                delayTime = (int)Math.Min(1000d, timeLeft.TotalMilliseconds);
                if (delayTime > 0)
                {
                    // don't forget the ConfigureAwait call:
                    // we don't need the context switch each time
                    await Task.Delay(delayTime, token).ConfigureAwait(false);
                }
            }
            while (delayTime > 0 && !token.IsCancellationRequested);
            if (!token.IsCancellationRequested)
            {
                action();
            }
        }
    }
