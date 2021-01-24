    services.AddAuthentication(options =>
    {
    	// the scheme name has to match the value we're going to use in AuthenticationBuilder.AddScheme(...)
        options.DefaultAuthenticateScheme = "Custom Scheme";
        options.DefaultChallengeScheme = "Custom Scheme";
    })
    .AddCustomAuth(o => { });
