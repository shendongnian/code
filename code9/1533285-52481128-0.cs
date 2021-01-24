    services.AddAuthentication(x =>
	{
		x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(x =>
	{
		x.Events = new JwtBearerEvents
		{
			OnTokenValidated = async context =>
			{
				var userService = context.HttpContext.RequestServices.GetRequiredService<IUserRoleStore<User>>();
				var username = context.Principal.Identity.Name;
				var user = await userService.FindByNameAsync(username, CancellationToken.None);
				if (user == null)
				{
					// return unauthorized if user no longer exists
					context.Fail("Unauthorized");
				}
				else
				{
					// Check if the roles are still valid.
					var roles = await userService.GetRolesAsync(user, CancellationToken.None);
					foreach (var roleClaim in context.Principal.Claims.Where(p => p.Type == ClaimTypes.Role))
					{
						if (roles.All(p => p != roleClaim.Value))
						{
							context.Fail("Unauthorized");
							return;
						}
					}
					context.Success();
				}
			},
			OnMessageReceived = context =>
			{
				var accessToken = context.Request.Query["access_token"];
				// If the request is for our hub...
				var path = context.HttpContext.Request.Path;
				if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
				{
					// Read the token out of the query string
					context.Token = accessToken;
				}
				return Task.CompletedTask;
			}
		};
		x.RequireHttpsMetadata = false;
		x.SaveToken = true;
		x.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
