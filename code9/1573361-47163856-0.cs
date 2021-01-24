    app.UseOpenIdConnectAuthentication(
        new OpenIdConnectAuthenticationOptions {
		   ...
		   Notifications = new OpenIdConnectAuthenticationNotifications {
               AuthorizationCodeReceived = async code => {
                   ClientCredential credential = new ClientCredential(Startup.clientId, Startup.appKey);
                   AuthenticationContext authContext = new AuthenticationContext(Startup.authority, false);
                   AuthenticationResult result = await authContext.AcquireTokenByAuthorizationCodeAsync(
			           code.Code,
                       new Uri(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Path)), 
                       credential, 
                       Startup.apiResourceId);
               }
           }
