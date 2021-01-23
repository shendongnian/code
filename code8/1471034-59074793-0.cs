    using Microsoft.IdentityModel.Protocols;
    using Microsoft.IdentityModel.Protocols.OpenIdConnect;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading;
    using System.Threading.Tasks;
        public static async Task<JwtSecurityToken> VerifyAndDecodeJwt(string accessToken)
        {
            try
            {
                var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{securityApiOrigin}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
                var openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    RequireSignedTokens = true,
                    IssuerSigningKeys = openIdConfig.SigningKeys,
                };
                new JwtSecurityTokenHandler().ValidateToken(accessToken, validationParameters, out var validToken);
                // threw on invalid, so...
                return validToken as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                logger.Info(ex.Message);
                return null;
            }
        }
