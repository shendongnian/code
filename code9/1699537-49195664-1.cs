    public static List<SecurityKey> MyIssuerSigningKeyResolver(string token, SecurityToken jwtToken, string kid, TokenValidationParameters validationParameters)
    {
            List<SecurityKey> keys = new List<SecurityKey>();
    
            if (validationParameters == null)
            {
                throw new ArgumentNullException("validationParameters");
            }
    
            if (jwtToken == null)
            {
                throw new ArgumentNullException("securityToken");
            }
    
            if (!string.IsNullOrEmpty(kid))
            {
                SymmetricSecurityKey key = SecurityKeyManager.GetSecurityKey(kid);
    
                keys.Add(key);
            }
    
            return keys;
    }
