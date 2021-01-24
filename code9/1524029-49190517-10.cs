    public static class AuthJwtTokenOptions
    {
        public const string Issuer = "SomeIssuesName";
        public const string Audience = "https://awesome-website.com/";
        private const string Key = "supersecret_secretkey!12345";
        public static SecurityKey GetSecurityKey() =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
    }
