	services.AddAuthentication(options =>
	{
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; // overidden from AddIdentity
		
		options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme; // set in AddIdentity
		options.DefaultSignInScheme = IdentityConstants.ExternalScheme; // set in AddIdentity
		
        options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme; // via options.DefaultScheme
		options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme; // via options.DefaultScheme
	});
