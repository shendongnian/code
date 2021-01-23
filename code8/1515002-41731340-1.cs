    public async Task<AuthenticationResult> Authenticate(UIViewController controller, string authority, string resource, string clientId, string returnUri)
		{
			var authContext = new AuthenticationContext(authority);
			if (authContext.TokenCache.ReadItems().Any())
				authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
			var controller = UIApplication.SharedApplication.KeyWindow.RootViewController;
			var uri = new Uri(returnUri);
			var platformParams = new PlatformParameters(controller);
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
