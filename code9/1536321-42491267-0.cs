        public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
        {
    
            private readonly string _issuer = string.Empty;
            private ProvidersBL providerBL;
            public CustomJwtFormat(string issuer)
            {
                _issuer = issuer;
                providerBL = new ProvidersBL();
            }
    
            public string Protect(AuthenticationTicket data)
            {
                if (data == null)
                {
                    throw new ArgumentNullException("data");
                }
    
                string userName = String.Empty;
                var userNameClaim = data.Identity.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name");
                if (userNameClaim != null)
                {
                    userName = userNameClaim.Value;
                }
    
    
                string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
                string symmetricKeyAsBase64 = string.Empty;
                symmetricKeyAsBase64 = providerBL.GetKeyForUser(userName);
                if (String.IsNullOrWhiteSpace(symmetricKeyAsBase64))
                {
                    symmetricKeyAsBase64 = ConfigurationManager.AppSettings["as:AudienceSecret"];
                }
                
    
                var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);
                var signingKey = new HmacSigningCredentials(keyByteArray);
    
    
                var issued = data.Properties.IssuedUtc;
                var expires = data.Properties.ExpiresUtc;
                var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);
                var handler = new JwtSecurityTokenHandler();
                var jwt = handler.WriteToken(token);
                return jwt;
            }
    
            public AuthenticationTicket Unprotect(string protectedText)
            {
                throw new NotImplementedException();
            }
        }
