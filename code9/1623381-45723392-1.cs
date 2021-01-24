        static private SymmetricSecurityKey GetSignInKey()
        {
            const string secretKey = "very_long_very_secret_secret";
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            return signingKey;
        }
        static private string GetIssuer()
        {
            return "issuer";
        }
        static private string GetAudience()
        {
            return "audience";
        }
