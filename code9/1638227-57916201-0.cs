        public class TestSetup
        {
            public TestSetup()
            {
                var serviceCollection = new ServiceCollection();
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(
                         path: "appsettings.json",
                         optional: false,
                         reloadOnChange: true)
                   .Build();
                serviceCollection.AddSingleton<IConfiguration>(configuration);
                serviceCollection.AddTransient<MyController, MyController>();
    
                ServiceProvider = serviceCollection.BuildServiceProvider();
            }
    
            public ServiceProvider ServiceProvider { get; private set; }
        }
