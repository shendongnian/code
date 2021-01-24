    public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }
    
            public IConfiguration Configuration { get; }
    
            // Configure Unity container
            public void ConfigureContainer(IUnityContainer container)
            {
                container.RegisterSingleton<IUserRepository, UserRepository>();
            }
    
            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                // Container could be configured via services as well. 
                // Just be careful not to override registrations
                services.AddDbContext<ApplicationContext>(opts =>
                       opts.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));
           
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAllOrigins",
                        builder =>
                        {
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
                });
    
                // Add MVC as usual
                services.AddMvcCore().AddJsonFormatters();
            }
    
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment()) {
                    app.UseDeveloperExceptionPage();
                }
    
                app.UseMvc();
            }
        }
