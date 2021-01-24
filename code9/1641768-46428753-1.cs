    app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
    {
    	// Snip
    	Notifications = new OpenIdConnectAuthenticationNotifications
    	{
    		AuthorizationCodeReceived = async n =>
    		{
    			// Snip
    		},
    		RedirectToIdentityProvider = n =>
    		{
    			// Snip
    			n.HandleResponse(); // The magic happens here
    		}
    }
     
