       public interface IStartupJob
        {
            Task ExecuteAsync(CancellationToken stoppingToken);
        }
    
        public class DBJob : IStartupJob
        {
            public Task ExecuteAsync(CancellationToken stoppingToken)
            {
                return Task.Run(() => System.Threading.Thread.Sleep(10000));
            }
        }
    
        public class StartupJobService<TJob> : IHostedService, IDisposable where TJob: class,IStartupJob
        {
            //This ensures a single start of the task this is important on a singletone
            private readonly Lazy<Task> _executingTask;
    
            private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
    
            public StartupJobService(Func<TJob> factory)
            {
                //In order for the transient item to be in memory as long as it is needed not to be in memory for the lifetime of the singleton I use a simple factory
                _executingTask = new Lazy<Task>(() => factory().ExecuteAsync(_stoppingCts.Token));
            }
    
            //You can use this to tell if the job is done
            public virtual Task Done => _executingTask.IsValueCreated ? _executingTask.Value : throw new Exception("BackgroundService not started");
    
            public virtual Task StartAsync(CancellationToken cancellationToken)
            {
                
                if (_executingTask.Value.IsCompleted)
                {
                    return _executingTask.Value;
                }
    
                return Task.CompletedTask;
            }
    
            public virtual async Task StopAsync(CancellationToken cancellationToken)
            {
                if (_executingTask == null)
                {
                    return;
                }
    
                try
                {
                    _stoppingCts.Cancel();
                }
                finally
                {
                    await Task.WhenAny(_executingTask.Value, Task.Delay(Timeout.Infinite,
                                                                  cancellationToken));
                }
    
            }
    
            public virtual void Dispose()
            {
                _stoppingCts.Cancel();
            }
    
            public static void AddService(IServiceCollection services)
            {
                //Helper to register the job
                services.AddTransient<TJob, TJob>();
    
                services.AddSingleton<Func<TJob>>(cont => 
                {
                    return () => cont.GetService<TJob>();
                });
    
                services.AddSingleton<IHostedService, StartupJobService<TJob>>();
            }
        }
