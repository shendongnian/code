    public void ConfigureServices(IServiceCollection services)
    {
        // Other code here…
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthJwtTokenOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthJwtTokenOptions.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthJwtTokenOptions.GetSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });
        // Other code here…
        services.AddMvc();
    }
