    services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
    services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(10));
    services.AddAuthentication()
        .Services.ConfigureApplicationCookie(options =>
        {
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        });
