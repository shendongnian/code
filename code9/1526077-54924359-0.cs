    app.UseAuthentication();
    // If you don't want the cookie to be automatically authenticated and assigned HttpContext.User, 
    // remove the CookieAuthenticationDefaults.AuthenticationScheme parameter passed to AddAuthentication.
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => 
        {
            options.LoginPath = "/Account/LogIn";
            options.LogoutPath = "/Account/LogOff";
        });
