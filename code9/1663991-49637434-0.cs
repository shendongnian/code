     public AuthenticationTicket Unprotect(string protectedText)
        {
         
            if (string.IsNullOrWhiteSpace(protectedText))
            {
                throw new ArgumentNullException("protectedText");
            }
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            string symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadToken(protectedText);
            SecurityToken validatedToken;
            string t = ((JwtSecurityToken)token).RawData;
            var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
            //var signingKey = new HmacSigningCredentials(keyByteArray);
            
            var validationParams = new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidAudience = audienceId,
                ValidIssuer = audienceId,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningToken = new BinarySecretSecurityToken(keyByteArray)
            };
            var principal = handler.ValidateToken(t, validationParams, out validatedToken);
            var identity = principal.Identities;
            return new AuthenticationTicket(identity.First(), new AuthenticationProperties());
            
        }
