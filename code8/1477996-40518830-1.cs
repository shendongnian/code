        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = env;
        }
        public IConfigurationRoot Configuration { get; }
        private IHostingEnvironment Environment { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddEntityFrameworkSqlite().AddDbContext<LynxJournalDbContext>();
            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IHostingEnvironment>(Environment);
            Services = services;
        }
