    class ToDoContextFactory : IDbContextFactory<ToDoContext>
    {
        public ToDoContext Create(DbContextFactoryOptions options)
        {
            var serviceCollection = new ServiceCollection()
                .AddLogging();
            new Startup().ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetRequiredService<ToDoContext>();
        }
    }
