        public ActivityMonitorService( )
        { 
        }
        public DateTime LastClick { get; private set; }
        public TimeSpan MaxLength { get; private set; }
        public void Start(TimeSpan maxDuration, Action expirationCallback = null)
        {
            MaxLength = maxDuration;
            Notify();
            _expirationCallBack = expirationCallback;
            ResetTimer();
        }
        public void Notify()
        { 
            LastClick = DateTime.Now;
        }
        public void Stop()
        {
        }
        public TimeSpan TimeSinceLastNotification()
        {
            var now = DateTime.Now;
            var timeSinceLastClick = now - LastClick;
            return timeSinceLastClick;
        }
        public TimeSpan GetNewTimerSpan()
        {
            var newDuration = MaxLength - TimeSinceLastNotification();
            return newDuration;
        }
        public bool IsExpired(DateTime time)
        {
            return time - LastClick > MaxLength;
        }
        private bool CallBack()
        {
            if (IsExpired(DateTime.Now))
            {
                Expire();
            }
            else
            {
                ResetTimer();
            }
            return false;
        }
        public async void Expire()
        {
            if (_expirationCallBack != null)
                _expirationCallBack.Invoke();
            Stop(); 
            //Notify user of logout
            //Do logout navigation
        }
        private void ResetTimer()
        {
            Device.StartTimer(GetNewTimerSpan(), CallBack);
        }
    }
