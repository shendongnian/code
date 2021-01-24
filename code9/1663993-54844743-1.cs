        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
            //var signingKey = new HmacSigningCredentials(keyByteArray);
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            securityKey.KeyId = ConfigurationManager.AppSettings["as:AudienceId"];
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingCredentials);
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);
            return jwt;
        }
        public AuthenticationTicket Unprotect(string protectedText)
        {
            string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            string authority = ConfigurationManager.AppSettings["Authority"];
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
            var signingKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(keyByteArray);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidAudience = audienceId,
                ValidIssuer = _issuer,
                IssuerSigningKey = signingKey,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true
            };
            var handler = new JwtSecurityTokenHandler();
            SecurityToken token = null;
            // Unpack token
            var pt = handler.ReadJwtToken(protectedText);
            string t = pt.RawData;
            var principal = handler.ValidateToken(t, tokenValidationParameters, out token);
            var identity = principal.Identities;
            return new AuthenticationTicket(identity.First(), new AuthenticationProperties());
        }
