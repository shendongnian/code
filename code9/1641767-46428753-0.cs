    protected override async Task ApplyResponseGrantAsync()
    {
    	AuthenticationResponseRevoke signout = Helper.LookupSignOut(Options.AuthenticationType, Options.AuthenticationMode);
    	
    	if (signout != null)
    	{
    		// snip
    		var notification = new RedirectToIdentityProviderNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>(Context, Options)
    		{
    			ProtocolMessage = openIdConnectMessage
    		};
    		
    		await Options.Notifications.RedirectToIdentityProvider(notification);
            // This was causing the issue
    		if (!notification.HandledResponse)
    		{
    			string redirectUri = notification.ProtocolMessage.CreateLogoutRequestUrl();
    			if (!Uri.IsWellFormedUriString(redirectUri, UriKind.Absolute))
    			{
    				_logger.WriteWarning("The logout redirect URI is malformed: " + redirectUri);
    			}
    			Response.Redirect(redirectUri);
    		}
    	}
    }
