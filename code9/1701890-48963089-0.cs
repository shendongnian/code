	app.UseCookieAuthentication(new CookieAuthenticationOptions
	{
		Provider = new CookieAuthenticationProvider
		{
			OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
				validateInterval: TimeSpan.FromMinutes(1),
				regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
		},
		// other stuff
	});
