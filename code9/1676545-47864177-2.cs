    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public Startup(IHostingEnvironment env)
        {
            // Create configuration as you need it...
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(...)
                .AddEnvironmentVariables();
            // Save configuration in property to access it later.
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Register all your desired services...
            services.AddMvc(options => ...);
            // Call our helper method
            services.RegisterOptions(Configuration);
        }
    }
