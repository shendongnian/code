    public class PeriodicaBackgroundJobRunner : IPeriodicaBackgroundJobRunner
    {
        private CancellationTokenSource cancellationToken;
    
        public void Start(int interval, IPeriodicalJob job)
        {
            Task.Run(async () =>
            {
                interval = Math.Max(interval, 1) * 1000;
    
                this.cancellationToken = new CancellationTokenSource();
    
                while (true)
                {
                    job.Execute(null);
                    await Task.Delay(interval, this.cancellationToken.Token);
                }
            });
        }
    
        public void Stop()
        {
            if (this.cancellationToken != null)
            {
                this.cancellationToken.Cancel();
            }
        }
    }
