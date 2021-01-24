    public void ConfigureAuth(IAppBuilder app)
    {
        // Configure the db context and user manager to use a single instance per request
        app.CreatePerOwinContext(ApplicationDbContext.Create);
        app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        // Enable the application to use a cookie to store information for the signed in user
        // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        app.UseCookieAuthentication(new CookieAuthenticationOptions());
        app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        // Configure the application for OAuth based flow
        PublicClientId = "self";
        OAuthOptions = new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/Token"),
            Provider = new ApplicationOAuthProvider(PublicClientId),
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
            // In production mode set AllowInsecureHttp = false
            AllowInsecureHttp = true
        };
        // Enable the application to use bearer tokens to authenticate users
        app.UseOAuthBearerTokens(OAuthOptions);
        app.UseWindowsAzureActiveDirectoryBearerAuthentication(
          new WindowsAzureActiveDirectoryBearerAuthenticationOptions
          {
              Audience = ConfigurationManager.AppSettings["ida:Audience"],
              Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
          });    
    }
