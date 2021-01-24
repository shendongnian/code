	// default authentification
	var authBuilder = services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme; // use cookies for authentication, with Identity validation
		options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;  // use our own cookies for persistence
		options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme; // use our own cookies for persistence
		options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; // use Azure AD for challenges
	});
	// cookie authentification
	authBuilder.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
	{
		options.ExpireTimeSpan = TimeSpan.FromDays(7);
	});
