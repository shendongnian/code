	using System.Configuration;
	using System.Net.Http;
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.Graph;
	using Microsoft.IdentityModel.Clients.ActiveDirectory;
	namespace <PROJECT_NAME>.Models
	{
		class AzureAuthenticationProvider : IAuthenticationProvider
		{
			private string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
			private string appKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
			private string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
			public async Task AuthenticateRequestAsync(HttpRequestMessage request)
			{
				string signedInUserID = ClaimsPrincipal.Current.FindFirst(ClaimTypes.NameIdentifier).Value;
				string tenantID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid").Value;
				// get a token for the Graph without triggering any user interaction (from the cache, via multi-resource refresh token, etc)
				ClientCredential creds = new ClientCredential(clientId, appKey);
				// initialize AuthenticationContext with the token cache of the currently signed in user, as kept in the app's database
				AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID, new ADALTokenCache(signedInUserID));
				AuthenticationResult authResult = await authenticationContext.AcquireTokenAsync("https://graph.microsoft.com/", creds);
				request.Headers.Add("Authorization", "Bearer " + authResult.AccessToken);
			}
		}
	}
