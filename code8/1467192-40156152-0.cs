    services.AddIdentity<ApplicationUser, IdentityRole>(o =>
    {
        o.Password.RequireNonAlphanumeric = false;
        o.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(24);
        o.Cookies.ApplicationCookie.SlidingExpiration = true;
    })
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();	
