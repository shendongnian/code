    public class MyClass
    {
        public void MyMethod(IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var logFactory = this.serviceProvider.GetRequiredService<ILogFactory>();
            var log = logFactory.CreateLog<ServiceApplication>();
            log.LogInformation("Hello, World!");
        }
    }
