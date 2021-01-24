    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();
        services.AddSession();
        services.AddDbContext<UserDashContext>(options => options.UseNpgsql(Configuration["DBInfo:ConnectionString"]));
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<UserDashContext>()
            .AddDefaultTokenProviders();
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            // Lockout settings
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 10;
            // Cookie settings
            options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
            options.Cookies.ApplicationCookie.LoginPath = "/signin";
            options.Cookies.ApplicationCookie.LogoutPath = "/logout";
            options.User.RequireUniqueEmail = true;
        });
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        InitializeRoles(app.ApplicationServices).Wait();
        loggerFactory.AddConsole();
        // app.UseCookieAuthentication(new CookieAuthenticationOptions()
        // {
        //     AuthenticationScheme = "Cookies",
        //     LoginPath = "/signin",
        //     AccessDeniedPath = new PathString("/notAllowedRoute"),
        //     AutomaticAuthenticate = false,
        //     AutomaticChallenge = true
        // });
        app.UseIdentity();
        app.UseDeveloperExceptionPage();
        app.UseStaticFiles();
        app.UseSession();
        app.UseMvc();
    }
