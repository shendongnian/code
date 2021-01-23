    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    namespace SomeProject.Test
    {
    public static class TestEnvironment
    {
        private static object configLock = new object();
        public static ServiceProvider ServiceProvider { get; private set; }
        public static T GetOption<T>()
        {
            lock (configLock)
            {
                if (ServiceProvider != null) return (T)ServiceProvider.GetServices(typeof(T)).First();
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("config/appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
                var configuration = builder.Build();
                var services = new ServiceCollection();
                services.AddOptions();
                services.Configure<ProductOptions>(configuration.GetSection("Products"));
                services.Configure<MonitoringOptions>(configuration.GetSection("Monitoring"));
                services.Configure<WcfServiceOptions>(configuration.GetSection("Services"));
                ServiceProvider = services.BuildServiceProvider();
                return (T)ServiceProvider.GetServices(typeof(T)).First();
            }
        }
    }
    }
