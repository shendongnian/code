    public class IncomingEthTxService : BackgroundService
        {
            public IncomingEthTxService(IServiceScopeFactory scopeFactory) : base(scopeFactory)
            {
            }
    
            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
    
                while (!stoppingToken.IsCancellationRequested)
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<NautilusDbContext>();
    
                        Console.WriteLine("[IncomingEthTxService] Service is Running");
    
                        // Run something
    
                        await Task.Delay(5, stoppingToken);
                    }
                }
            }
        }
