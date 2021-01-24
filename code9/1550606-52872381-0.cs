    static string _issuer = string.Empty;
    static List<X509SecurityToken> _signingTokens = null;    
    var stsMetadataAddress = "Your Metadata URL";
    static string _audience = "your Audience URL"; //app id
    GetTenantInformation(stsMetadataAddress, out issuer, out signingTokens);
    Microsoft.IdentityModel.Tokens.SecurityKey key = new 
    X509SecurityKey(signingTokens.FirstOrDefault().Certificate);
    TokenValidationParameters validationParameters = new TokenValidationParameters
    {
       ValidAudience = _audience,
       ValidIssuer = issuer,
       IssuerSigningKey = key
    };
                   
