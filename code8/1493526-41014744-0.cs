    using System.Threading;
    using Timer = System.Timers.Timer;
    internal class JobTimer : IDisposable
    {
        private readonly object _objectLock = new object();
        private readonly ReaderWriterLockSlim timerLock = new ReaderWriterLockSlim();
        private DateTime lastExec = DateTime.MinValue;
        private Timer _timer;
        public JobTimer()
        {
            this._timer = new Timer(1000);
            this._timer.Elapsed += this.TimerEvent;
        }
        private event EventHandler JobDueEvent;
        public void Start()
        {
            if (_timer != null)
            {
                _timer.Dispose();
            }
            this._timer = new Timer(1000);
            this._timer.Elapsed += this.TimerEvent;
            this._timer.Start();
			
			var interval = 1;
            this.lastExec = DateTime.UtcNow.Date.AddMinutes(
               (Math.Floor(currentTime.TimeOfDay.TotalMinutes / interval) + 1) * 
               interval).Subtract(TimeSpan.FromMinutes(1));
        }
        public void Stop()
        {
            this._timer.Stop();
        }
        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }
        private void TimerEvent(object timerInfo, ElapsedEventArgs args)
        {
            try
            {
                this.timerLock.EnterWriteLock();
                if (lastExec.Add(TimeSpan.FromMinutes(1)) < DateTime.UtcNow)
                {
                    lastExec = lastExec.Add(TimeSpan.FromMinutes(1));
					// DO WHAT YOU WANT TO DO WHEN THE TIMER FIRES
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                this.timerLock.ExitWriteLock();
            }
        }
    }
