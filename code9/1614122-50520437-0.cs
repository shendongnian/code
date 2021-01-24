            string token = // ... read the token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = ...;
            SecurityToken securityToken;
            IPrincipal principal;
            try
            {
                // token validation
                principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                // Reading the "verificationKey" claim value:
                var vk = principal.Claims.SingleOrDefault(c => c.Type == "verificationKey").Value; 
            }
            catch
            {
                principal = null; // token validation error
            }
