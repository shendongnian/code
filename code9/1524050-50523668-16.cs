	// ===== Add Jwt Authentication ========
	JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
	// jwt
	// get options
	var jwtAppSettingOptions = Configuration.GetSection("JwtIssuerOptions");
	services
		.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer(cfg =>
		{
			cfg.RequireHttpsMetadata = false;
			cfg.SaveToken = true;
			cfg.TokenValidationParameters = new TokenValidationParameters
			{
				ValidIssuer = jwtAppSettingOptions["JwtIssuer"],
				ValidAudience = jwtAppSettingOptions["JwtIssuer"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions["JwtKey"])),
				ClockSkew = TimeSpan.Zero // remove delay of token when expire
			};
		});
