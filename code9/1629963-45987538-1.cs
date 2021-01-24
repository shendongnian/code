	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Configuration;
	using System.Linq;
	using System.Security.Claims;
	using System.Web;
	using System.Web.Mvc;
	using System.Threading.Tasks;
	using Microsoft.Azure.ActiveDirectory.GraphClient;	// Will eventually be removed
	using Microsoft.IdentityModel.Clients.ActiveDirectory;
	using Microsoft.Owin.Security;
	using Microsoft.Owin.Security.OpenIdConnect;
	using <PROJECT_NAME>.Models;
	using Microsoft.Graph;
	using User = Microsoft.Graph.User;	// This is only here while I work on removing references to Microsoft.Azure.ActiveDirectory.GraphClient
	namespace <PROJECT_NAME>.Controllers
	{
		[Authorize]
		public class UserProfileController : Controller
		{
			public async Task<List<User>> GetAllUsers()
			{
				List<User> userResult = new List<User>();
				GraphServiceClient graphClient = new GraphServiceClient(new AzureAuthenticationProvider());
				IGraphServiceUsersCollectionPage users = await graphClient.Users.Request().Top(500).GetAsync();	// The hard coded Top(500) is what allows me to pull all the users, the blog post did this on a param passed in
				userResult.AddRange(users);
				while (users.NextPageRequest != null)
				{
					users = await users.NextPageRequest.GetAsync();
					userResult.AddRange(users);
				}
				return userResult;
			}
			
			// Return all users from Azure AD as a proof of concept
			public async Task<ActionResult> Admin()
			{
				try
				{
					var user = await GetAllUsers();
					return View(user
						);
				}
				catch (AdalException)
				{
					// Return to error page.
					return View("Error");
				}
				// if the above failed, the user needs to explicitly re-authenticate for the app to obtain the required token
				catch (Exception)
				{
					return View("Relogin");
				}
			}
		}
	}
