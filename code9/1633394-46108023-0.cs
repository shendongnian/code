    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateLifetime = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is super secret")),
        ValidateActor = false
    };
