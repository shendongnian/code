    public static ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;
            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.ValidateLifetime = true;
            validationParameters.ValidAudience = _audience.ToLower();
            validationParameters.ValidIssuer = _issuer.ToLower();
            validationParameters.IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);
            return principal;
        }
