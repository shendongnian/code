    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: true)
                .SetBasePath(env.ContentRootPath)
                .Build();
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataContext(Configuration);
            services.AddIdentity<ApplicationUser, IdentityRole>(p =>
            {
                p.Password.RequireDigit = false;
                p.Password.RequireLowercase = false;
                p.Password.RequireUppercase = false;
                p.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<MyShuttleContext>()
            .AddDefaultTokenProviders();
            services.ConfigureDependencies();
            services.AddMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseAuthentication();
            app.ConfigureRoutes();
        }
    }
