    class RepeatableProcess
    {
        private Timer  processTimer;
        private int delay;
        private CancellationTokenSource source;
        private CancellationToken token;
        private Action processToRun;
        private bool canStart = true;
        
        public RepeatableProcess(int delaySeconds,Action process)
        {
            delay = delaySeconds;
            processToRun = process;
        }
        public void Start()
        {
            if (canStart)
            {
                canStart = false;
                source = new CancellationTokenSource();
                token = source.Token;
                processTimer = new Timer(TimedProcess, token, Timeout.Infinite, Timeout.Infinite);
                processTimer.Change(0, Timeout.Infinite);
            }
            
        }
        public void Stop()
        {
            source.Cancel();
        }
        public void TimedProcess(object state)
        {
            
            CancellationToken ct = (CancellationToken)state;
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("Timer Stopped");
                processTimer.Dispose();
                canStart = true;
            }
            else
            {
                processToRun.Invoke();
                processTimer.Change(delay, Timeout.Infinite);
            }
        }
        
    }
