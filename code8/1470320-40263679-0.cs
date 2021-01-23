    public static class IdentityExtensions
    {
        public static string FullName(this IIdentity identity)
        {
            return ((ClaimsIdentity)identity).FindFirst("FullName").Value;
        }
    }
