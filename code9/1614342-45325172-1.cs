    public void ConfigureAuth(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
            // here you go
            ExpireTimeSpan = new TimeSpan(60000000000)
        });
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }
