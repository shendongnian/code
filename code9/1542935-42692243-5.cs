    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
    static Startup()
    {
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/token"),
            Provider = new OAuthAppProvider(),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(2),
            AllowInsecureHttp = true
        };
    }
    public void ConfigureAuth(IAppBuilder app)
    {   
        app.UseOAuthAuthorizationServer(OAuthOptions);
        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
    }
