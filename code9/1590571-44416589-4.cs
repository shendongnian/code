    public static class PrincipalExtensions
    {
        public static string GetClientId(this IPrincipal principal)
        {
            return (principal.Identity as ClaimsIdentity)?
                .Claims
                .FirstOrDefault(c => c.Type == "oauth-client")?
                .Value;
        }    
    }
