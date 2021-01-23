    private static void ConfigureAuthentication(IAppBuilder app)
    {
    	var issuer = "<<MyIssuer>>";
    	var audience = "<<MyAudience>>";
    
    	const string publicKeyBase64 = "<<MyPublicKeyBase64>>";
    
    	var certificate = new X509Certificate2(Convert.FromBase64String(publicKeyBase64));
    
    	app.UseJwtBearerAuthentication(
    		new JwtBearerAuthenticationOptions
    		{
    			AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
    			AllowedAudiences = new[] { audience },
    			IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
    			{
    			  new X509CertificateSecurityTokenProvider(issuer, certificate),
    			},
    			TokenValidationParameters = new TokenValidationParameters
    			{
    				IssuerSigningKeyResolver = (a, b, c, d) => new X509SecurityKey(certificate),
    				ValidAudience = audience,
    				ValidIssuer = issuer
    			}			
    		}
    	);
    }
