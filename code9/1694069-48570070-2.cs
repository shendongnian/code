    public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use cookies to authenticate users
            app.UseCookieAuthentication(CookieOptions);
            // Enable the application to use a cookie to store temporary information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(ExternalCookieAuthenticationType);
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions, ExternalOAuthAuthenticationType);
            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");
            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");
            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");
            //app.UseGoogleAuthentication();
        }
