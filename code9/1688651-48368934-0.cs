    public class MyHostedService : IHostedService
    {
        private readonly IServiceScopeFactory scopeFactory;
        public MyHostedService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        public void DoWork()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                …
            }
        }
        …
    }
