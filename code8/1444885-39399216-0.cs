    public class DebugWatchDog : IDisposable
    {
        private bool Terminated;
        private Action<DateTime> updateEndTime;
        private DateTime endTime;
        public DebugWatchDog(Action<DateTime> updateEndTime, DateTime endTime)
        {
            if (!System.Diagnostics.Debugger.IsDebuggerAttached)
                return;
            this.updateEndTime = updateEndTime;
            updateEndTime(DateTime.MaxValue);
            var thread = new Thread(Watch);
            thread.Start();
        }
        public void Dispose()
        {
            lock (this)
                Terminated = true;
        }
        public void Watch()
        {
            DateTime priorTime = DateTime.UtcNow;
            while (true)
            {
                lock (this)
                    if (Terminated)
                        return;
                Thread.Sleep(100);
                DateTime nextTime = DateTime.UtcNow;
                var diff = nextTime - priorTime;
                if (diff.TotalMilliseconds > 115)
                {
                    endTime += diff;
                }
                if (DateTime.UtcNow > endTime)
                {
                    updateEndTime(endTime);
                    return;
                }
                priorTime = nextTime;
            }
        }
    }
