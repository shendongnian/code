    public class Timer    {
            public Timer(int interval)
            {
                _interval = TimeSpan.FromMilliseconds(interval);
            }
    
            private bool _isRunning;
            private readonly TimeSpan _interval;
    
            private Action Tick;
    
            public void Start(Action tick)
            {
                _isRunning = true;
                Tick = tick;
                Xamarin.Forms.Device.StartTimer(_interval,() =>
                {
                    Tick?.Invoke();
                    return _isRunning;
                });
            }
    
            public void Stop()
            {
                _isRunning = false;
                Tick = null;
            }
        }
