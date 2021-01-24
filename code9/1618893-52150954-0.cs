            string issuerEndpoint = "https://my.auth.server";
            var openidConfiguration = await OpenIdConnectConfigurationRetriever.GetAsync(
                        $"{issuerEndpoint}/.well-known/openid-configuration", CancellationToken.None);
            app.UseJwtBearerAuthentication(
            new Microsoft.Owin.Security.Jwt.JwtBearerAuthenticationOptions()
            {
                TokenValidationParameters =
                    new TokenValidationParameters
                    {
                        ValidIssuer = openidConfiguration.Issuer,
                        ValidateAudience = false,
                        IssuerSigningKeys = openidConfiguration.SigningKeys,
                        IssuerSigningTokens = openidConfiguration.SigningTokens
                    }
            });
