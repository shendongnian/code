    public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddAuthentication("tanushCookie")
            .AddCookie("tanushCookie", options => {
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
