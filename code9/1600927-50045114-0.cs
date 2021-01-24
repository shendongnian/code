    private string Authenticate(string token) {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        List<Exception> validationFailures = null;
        SecurityToken validatedToken;
        var validator = new JwtSecurityTokenHandler();
    
        TokenValidationParameters validationParameters = new TokenValidationParameters();
        validationParameters.ValidIssuer = "http://localhost:5000";
        validationParameters.ValidAudience = "http://localhost:5000";
        validationParameters.IssuerSigningKey = key;
        validationParameters.ValidateIssuerSigningKey = true;
        validationParameters.ValidateAudience = true;
    
        if (validator.CanReadToken(token))
        {
            ClaimsPrincipal principal;
            try
            {
                principal = validator.ValidateToken(token, validationParameters, out validatedToken);
                if (principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    return principal.Claims.Where(c => c.Type == ClaimTypes.Email).First().Value;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(null, e);
            }
        }
    
        return String.Empty;
    }
