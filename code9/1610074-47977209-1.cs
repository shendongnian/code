    public static class DatabaseSeedInitializer
    {
        public static IWebHost Seed(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    Task.Run(async () =>
                    {
                        var dataseed = new DataInitializer();
                        await dataseed.InitializeDataAsync(serviceProvider);
                    }).Wait();
                    
                }
                catch (Exception ex)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            return host;
        }
    }
