    public class JsonWebTokenValidator
    {
        public void Validate(string token)
        {
            var stsDiscoveryEndpoint = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration";
            var options = new JwtBearerOptions
            {
                ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint, new OpenIdConnectConfigurationRetriever()),
                TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://sts.windows.net/{tenantId}/",
                    ValidateAudience = true,
                    ValidAudience = "{audience}",
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                },
                Authority = "https://login.microsoftonline.com/{tenantId}",
            };
            SecurityToken validatedToken = null;
            ClaimsPrincipal result = null;
            var configuration = options.ConfigurationManager.GetConfigurationAsync(new CancellationToken()).Result;
            options.TokenValidationParameters.IssuerSigningKeys = configuration.SigningKeys;
            options.ConfigurationManager.RequestRefresh();
            foreach (var validators in options.SecurityTokenValidators)
            {
                result = validators.ValidateToken(token, options.TokenValidationParameters, out validatedToken);
            }
            foreach (var claim in result.Claims)
            {
                Console.WriteLine($"{claim.Subject}:{claim.Value}");
            }
        }
