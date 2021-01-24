    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            env.ConfigureNLog("nlog.config");
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ...
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            LogManager.Configuration.Variables["connectionString"] = 
                Configuration.GetConnectionString("DefaultConnection");
            ...
        }
    }
