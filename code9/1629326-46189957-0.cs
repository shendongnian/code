    public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddAuthentication("ACE_AUTH")
            .AddCookie("ACE_AUTH", options => {
                options.AccessDeniedPath = "/api/Auth/Forbidden";
                options.LoginPath = "/";
                options.Cookie.Expiration = new TimeSpan(7,0,0,0);
            });
        }
    public void Configure(IApplicationBuilder app, 
                          IHostingEnvironment env, 
                          ILoggerFactory loggerFactory)
        {
            ...
            app.UseAuthentication();
        }
