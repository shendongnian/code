    X509Certificate2 cert = new X509Certificate2("MySelfSignedCertificate.pfx", "password");
    SecurityKey key = new X509SecurityKey(cert); //well, seems to be that simple
    app.UseJwtBearerAuthentication(new JwtBearerOptions
    {
        AutomaticAuthenticate = true,
        AutomaticChallenge = true,
        TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "MyIssuer",
            ValidateAudience = true,
            ValidAudience = "MyAudience",
            ValidateLifetime = true,
            IssuerSigningKey = key
         }
    });
