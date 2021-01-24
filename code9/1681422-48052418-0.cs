    // add identity
    services.AddIdentity<ApplicationUser, IdentityRole>();
    // configure the application cookie
    services.ConfigureApplicationCookie(options =>
    {
        options.Cookie.SameSite = SameSiteMode.None;
    });
