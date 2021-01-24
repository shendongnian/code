    public void ConfigureServices(ServiceCollection services)
    {
        services.AddSession(options =>
        {
            // obsolete
            options.CookieName = "SessionCookie";
            options.CookieDomain = "contoso.com";
            options.CookiePath = "/";
            options.CookieHttpOnly = true;
            options.CookieSecure = CookieSecurePolicy.Always;
            // new API
            options.Cookie.Name = "SessionCookie";
            options.Cookie.Domain = "contoso.com";
            options.Cookie.Path = "/";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });
    }
