           var securityToken = fam.GetSecurityToken( request );
 
            var config = new SecurityTokenHandlerConfiguration
            {
                CertificateValidator = X509CertificateValidator.None,
                IssuerNameRegistry   = new CustomIssuerNameRegistry()
            };
            config.AudienceRestriction.AudienceMode = AudienceUriMode.Never;
 
            var tokenHandler = new SamlSecurityTokenHandler
            {
                CertificateValidator = X509CertificateValidator.None,
                Configuration        = config
            };
 
            // validate the token and get the ClaimsIdentity out of it
            var identity  = tokenHandler.ValidateToken( securityToken );
 
            var principal = new ClaimsPrincipal( identity );
