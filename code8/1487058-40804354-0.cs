        private ClaimsIdentity GetIdentityFromToken(string token, X509Certificate2 certificate)
        {  
            var tokenDecoder = new JwtSecurityTokenHandler();         
            var jwtSecurityToken = (JwtSecurityToken)tokenDecoder.ReadToken(token);
            SecurityToken validatedToken;
            var principal = tokenDecoder.ValidateToken(
                jwtSecurityToken.RawData,
                new TokenValidationParameters()
                    {
                        ValidateActor = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        RequireExpirationTime = false,
                        RequireSignedTokens = false,
                        IssuerSigningToken = new X509SecurityToken(certificate)
                    },
                out validatedToken);
            return principal.Identities.FirstOrDefault();
        }
