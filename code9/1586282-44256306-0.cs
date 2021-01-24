    public class Timer
    {
        CancellationTokenSource _cts = new CancellationTokenSource();
    
        public Task Wait(TimeSpan delay)
        {
            return Task.Delay(delay, _cts.Token);
        }
    
        public void Stop()
        {
            _cts.Cancel();
        }
    }
