    public class Startup
    {
        IConfigurationRoot Configuration { get; }
        public Startup()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IMyConfiguration, MyConfiguration>();
            services.AddSingleton(new LoggerFactory()
                    .AddNLog()
                    .ConfigureNLog("nlog.config")
                    );
            services.AddLogging();
            services.AddTransient<ConsoleApp>();
        }
    }
