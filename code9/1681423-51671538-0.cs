    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options => options.Cookie.SameSite = SameSiteMode.None;
    });
