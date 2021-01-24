    public void ConfigureAuth(IAppBuilder app)
    {
    	app.UseCors(CorsOptions.AllowAll);
    
    	//You don't need these lines if you are using bearer token as the token is 
        //passed in the request header and not in the cookie
    	//app.UseCookieAuthentication(new CookieAuthenticationOptions());
    	//app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    
    	OAuthOptions = new OAuthAuthorizationServerOptions
    	{
    		TokenEndpointPath = new PathString("/Token"),
    		Provider = new ApplicationOAuthProvider(PublicClientKey),
    		AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
    		AllowInsecureHttp = true
    	};
    	
    	//Remove this part
    	//app.UseOAuthBearerTokens(OAuthOptions);
    	
    	//And try to manually define the authorization server 
        //and the middleware to handle the tokens
    	app.UseOAuthAuthorizationServer(OAuthOptions);
    	app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
    } 
 
