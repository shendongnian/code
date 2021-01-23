       public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null)
                    return null;
                var symmetricKey = Convert.FromBase64String(Secret);
                var validationParameters = new TokenValidationParameters()
                {
                   RequireExpirationTime = true,
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {
                //should write log
                return null;
            }
        }
