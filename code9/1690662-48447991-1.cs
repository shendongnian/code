	services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
		options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
	})
	.AddCookie(IdentityConstants.ApplicationScheme, o =>
	{
		o.LoginPath = new PathString("/Account/Login");
		o.Events = new CookieAuthenticationEvents
		{
			OnValidatePrincipal = SecurityStampValidator.ValidatePrincipalAsync
		};
	})
	.AddCookie(IdentityConstants.ExternalScheme, o =>
	{
		o.Cookie.Name = IdentityConstants.ExternalScheme;
		o.ExpireTimeSpan = TimeSpan.FromMinutes(5);
	});
