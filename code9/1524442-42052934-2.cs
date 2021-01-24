    public class Startup : IStartup
    {
        public Startup(IHostingEnvironment env)
        {
            // constructor as usual
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public void Configure(IApplicationBuilder app) {            
            app.UseMvc();
            // resolve services from container
            var env = (IHostingEnvironment) app.ApplicationServices.GetService(typeof(IHostingEnvironment));
            var logger = (ILoggerFactory)app.ApplicationServices.GetService(typeof(ILoggerFactory));
            logger.AddConsole(Configuration.GetSection("Logging"));
            logger.AddDebug();
            // etc
        }        
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            // etc
            // return provider
            return services.BuildServiceProvider();
        }
    }
