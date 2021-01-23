    public class Startup
    {
        private static MyDependency dependency;
        public Startup(IHostingEnvironment env)
        {
            dependency = new MyDependency();
            var instance = new MyClass(dependency);
            var builder = new ConfigurationBuilder()
                .SetBasePath(instance.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            // Register the dependency if it is required by other components.
            services.AddSingleton<MyDependency>(dependency);
            // Add framework services.
            services.AddMvc();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        // etc.
    }
