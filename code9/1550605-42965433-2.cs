    HMACSHA256 hmac = new HMACSHA256(Encoding.ASCII.GetBytes(key));
    var validationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(hmac.Key);
    };
