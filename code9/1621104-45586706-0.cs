    public static class Interval
    {
        public static System.Timers.Timer Set(Action action, int interval)
        {
            var timer = new System.Timers.Timer(interval);
            timer.Elapsed += (s, e) => { 
                timer.Enabled = false;
                action();
                timer.Enabled = true;
            };
            timer.Enabled = true;
            return timer;
        }
        public static void Stop(System.Timers.Timer timer)
        {
            timer.Stop();
            timer.Dispose();
        }
    }
