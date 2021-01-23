    public async Task<AuthenticationResult> Authenticate(string authority, string resource, string clientId, string returnUri)
	{
		var authContext = new AuthenticationContext(authority);
		if (authContext.TokenCache.ReadItems().Any())
			authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
		var uri = new Uri(returnUri);
		var platformParams = new PlatformParameters(PromptBehavior.Auto);
		try
		{
			var authResult = await authContext.AcquireTokenAsync(resource, clientId, uri, platformParams);
			return authResult;
		}
		catch (AdalException e)
		{
			return null;
		}
	}
