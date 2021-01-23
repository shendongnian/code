      string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1.."
      var tokenHandler = new JwtSecurityTokenHandler();
    //Read Token for Getting the User Details
      var parsedJwt = tokenHandler.ReadToken(token) as JwtSecurityToken; 
    
    //Create A Certificate Object that will read the .CER/.PEM/.CRT file as String
     X509Certificate2 clientCertificate = new X509Certificate2(Encoding.UTF8.GetBytes(CertficationString));
     var certToken = new X509SecurityToken(clientCertificate);
     var validationParameters = new TokenValidationParameters()
        {   
            IssuerSigningToken = certToken,
            ValidAudience = audience,
            ValidIssuer = issuer,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true
        };
       
        try
        {
           SecurityToken validatedToken;
           var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            
        }
        catch (Exception err)
        {
            Console.WriteLine("{0}\n {1}", err.Message, err.StackTrace);
        }
    
