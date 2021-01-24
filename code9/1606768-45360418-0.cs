    app.Use(async (context, next) =>
	{
		if (context.User.Identity.IsAuthenticated)
		{
			using (var scope = Container.BeginLifetimeScope())
			{
				// fetch resource identity scopes from userinfo endpoint
				var restService = scope.Resolve<IRestService>();
				var token = context.Request.Headers["Authorization"]
                  .ToString().Replace("Bearer ", string.Empty);
				
                restService.SetAuthorizationHeader("Bearer", token);
                // fetch data from my custom RestService class and 
                // serialize into my custom ScopeData object
				var data = await restService.Get<ScopeData>(
                  Configuration["IdentityServerUrl"], "connect/userinfo");
				if (data.IsSuccessStatusCode)
				{
							
					// add identity resource scopes to claims
					var claims = new List<Claim>
					{
						new Claim("user.organization", data.Result.Organization),
						new Claim("user.profile", data.Result.UserInfo)
					};
				}
				else
				{
					sLogger.Warn("Failed to retrieve identity scopes from profile service.");
					context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
				}
			}
		}
		await next();
    });
