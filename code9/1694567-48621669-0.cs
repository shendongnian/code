    services.AddAuthentication(o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.Authority = options.AADInstance + options.TenantId;
        o.Audience = options.Audience;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = $"{options.AADInstance}{options.TenantId}/v2.0"
        };
    });
