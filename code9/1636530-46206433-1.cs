    static string GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var certificate = new X509Certificate2(@"Test.pfx", "123");
        var securityKey = new X509SecurityKey(certificate);
    
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(),
            Issuer = "Self",
            IssuedAt = DateTime.Now,
            Audience = "Others",
            Expires = DateTime.MaxValue,
            SigningCredentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.RsaSha256Signature)
        };
    
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    static bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var certificate = new X509Certificate2(@"Test.cer");
        var securityKey = new X509SecurityKey(certificate);
    
        var validationParameters = new TokenValidationParameters
        {
            ValidAudience = "Others",
            ValidIssuer = "Self",
            IssuerSigningKey = securityKey
        };
    
        var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
        if (principal == null)
            return false;
        if (securityToken == null)
            return false;
    
        return true;
    }
