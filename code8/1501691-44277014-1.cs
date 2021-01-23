    public static IWebHost BuildWebHost(string[] args)
    {
    	var configuration = LoadConfiguration(args);
    
        // Use Startup as always, register IConfigurationRoot to services
    	return new WebHostBuilder()
    		.UseKestrel()
    		.UseConfiguration(configuration)
    		.ConfigureServices(s => s.AddSingleton<IConfigurationRoot>(configuration))
    		.UseStartup<Startup>()
            .Build();
    }
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            // You get configuration in Startup constructor or wherever you need
        }
    }
