	// setup identity
	services.AddIdentity<ApplicationUser, ApplicationRole>()
		.AddEntityFrameworkStores<MyMoneyDbContext>()
		.AddDefaultTokenProviders();
	// setup Jwt authentication
	services.AddAuthentication(options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
	{
		jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
            ...
