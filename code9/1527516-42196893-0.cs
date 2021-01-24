    public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            Provider = new ApplicationOAuthProvider(PublicClientId),
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            // In production mode set AllowInsecureHttp = false
            AllowInsecureHttp = true
        };
        // Enable the application to use bearer tokens to authenticate users
        app.UseOAuthBearerTokens(OAuthOptions);
