    public class Startup : IStartup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
     
        public IConfigurationRoot Configuration { get; set; }
     
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            return services.BuildServiceProvider();
        }
     
        public void Configure(IApplicationBuilder app)
        {
            var env = app.ApplicationServices.GetService<IHostingEnvironment>();
            var loggerFactory = app.ApplicationServices.GetService<ILoggerFactory>();
     
            // Set up application pipeline
        }
    }
