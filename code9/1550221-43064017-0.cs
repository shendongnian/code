    public static async Task<bool> GetAuthenticatedClient()
	{
		string oneDriveConsumerBaseUrl = "https://api.onedrive.com/v1.0";
		var scopes = new List<string>
		{
			"wl.signin",
			"wl.basic",
		};
		Task authTask;
		var onlineIdAuthProvider = new OnlineIdAuthenticationProvider(scopes.ToArray());
		authTask = onlineIdAuthProvider.RestoreMostRecentFromCacheOrAuthenticateUserAsync();
		oneDriveClient = new OneDriveClient(oneDriveConsumerBaseUrl, onlineIdAuthProvider);
		AuthProvider = onlineIdAuthProvider;
		try
		{
			await authTask;
			if (!AuthProvider.IsAuthenticated)
			{
				return false;
			}
		}
		catch (ServiceException exception)
		{
			// Swallow the auth exception but write message for debugging.
			//Debug.WriteLine(exception.Error.Message);
			return false;
		}
		return true;
	}
