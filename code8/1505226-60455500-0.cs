    public class Program
        {
    
            public static void Main(string[] args)
            {
                var services = new ServiceCollection();
    
                DependencyInjectionConfiguration.ConfigureDI(services);
    
                var serviceProvider = services.BuildServiceProvider();
    
                var receiver = serviceProvider.GetService<MyServiceInterface>();
                    
                receiver.YourServiceMethod();
            }
        }
    public static class DependencyInjectionConfiguration
        {
            public static void ConfigureDI(IServiceCollection services)
            {
                services.AddScoped<MyServiceInterface, MyService>();
                services.AddHttpClient<MyClient>(); // for example
            }
        }
