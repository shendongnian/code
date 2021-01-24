    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
    LoginPath = new PathString("/Account/Login"),
    Provider = new CookieAuthenticationProvider
    {
        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
            validateInterval: TimeSpan.FromMinutes(15),
            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
    },
    SlidingExpiration = true,
    ExpireTimeSpan = TimeSpan.FromMinutes(1)
    });
    app.Use(async (context, next) =>
    {
        var result = await context.Authentication.AuthenticateAsync(DefaultAuthenticationTypes.ApplicationCookie);
        if (result != null)
        {
            result.Properties.ExpiresUtc = null;
            result.Properties.IssuedUtc = null;
            context.Authentication.SignIn(result.Properties, result.Identity);
        }
        await next();
    });
