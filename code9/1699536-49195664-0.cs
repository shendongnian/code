    public static IServiceCollection AddJwtValidation(this IServiceCollection services)
    {
            IServiceProvider sp = services.BuildServiceProvider();
            ConfigRoot = sp.GetRequiredService<IConfigurationRoot>();
    
            tokenAudience = ConfigRoot["JwtToken:Audience"];
            tokenIssuer = ConfigRoot["JwtToken:Issuer"];
    
            SecurityKeyManager.Start();
    
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
            {
                options.Audience = tokenAudience;
                options.ClaimsIssuer = tokenIssuer;
                    
                options.TokenValidationParameters = new TokenValidationParameters
                {                    
                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    RequireSignedTokens = true,
                    IssuerSigningKeyResolver = MyIssuerSigningKeyResolver,
                    ....
