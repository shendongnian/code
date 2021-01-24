    public class StopStartupService : BackgroundService
        {
            protected override Task ExecuteAsync(CancellationToken stoppingToken)
            {
                System.Threading.Thread.Sleep(1000);
                return Task.CompletedTask;
            }
        }
