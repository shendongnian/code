    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Runner
    {
        class Program
        {
            public static async Task Main(string[] args)
            {
                var services = ConfigureServices(new ServiceCollection())
                    .BuildServiceProvider();
                await services.GetService<App>().RunAsync();
            }
    
            private static IServiceCollection ConfigureServices(IServiceCollection services)
            {
                var configuration = ConfigurationFactory.GetConfiguration();
    
                services
                    .AddSingleton(configuration)
                    .AddLogging(builder =>
                    {
                        var config = configuration.GetSection("Logging");
                        builder
                            .AddConfiguration(configuration.GetSection("Logging"))
                            .AddConsole()
                            .AddDebug()
                            .AddAWSProvider(configuration.GetAWSLoggingConfigSection().Config);
                    })
                        
                // add app
                services.AddTransient<App>();
    
                return services;
            }
        }
        public class App
        {
            private ILogger<App> Logger;
    
            public App(ILogger<App> logger)
            {
                Logger = logger;
            }
    
            public async Task RunAsync()
            {
                try
                {
                    Logger.LogTrace("LogTrace", "{\"Test\":1}");
                    Logger.LogInformation("LogInformation", "{\"Test\":2}");
                    Logger.LogWarning("LogWarning", "{\"Test\":3}");
                    Logger.LogDebug("LogDebug", "{\"Test\":4}");
                    Logger.LogError("LogError", "{\"Test\":5}");
                    Logger.LogCritical("LogCritical", "{\"Test\":6}");
                    Thread.Sleep(3000);
                    Debugger.Break();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
