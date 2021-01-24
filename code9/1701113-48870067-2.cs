    public abstract class Schedualer : IDisposable
    {
        private Timer _timer;
        public Schedualer(double interval)
        {
            _timer = new Timer(interval);
            _timer.Elapsed += _timer_Elapsed;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_timer != null)
                {
                    _timer.Elapsed -= _timer_Elapsed;
                    _timer.Dispose();
                }
            }
        }
        protected abstract void OnTimerElapsed();
        protected void StartTimer()
        {
            _timer.Start();
        }
        protected void StopTimer()
        {
            _timer.Stop();
        }
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            try
            {
                TimerElapsed();
            }
            finally 
            {
                _timer.Start();
            }
        }
    }
