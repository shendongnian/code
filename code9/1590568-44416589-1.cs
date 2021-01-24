    public static class PrincipalExtensions
    {
        public static string GetClientId(this IPrincipal principal)
        {
            return (User.Identity as ClientIdentity)?
                .Claims
                .FirstOrDefault(c => c.Type == "oauth-client")?
                .Value;
        }    
    }
