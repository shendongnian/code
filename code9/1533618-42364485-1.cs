    public static class IdentityExtensions
        {
            public static Guid GetMyClaim(this IIdentity identity)
            {
                var claim = ((ClaimsIdentity)identity).FindFirst("Your claim name");
                return (claim != null) ? claim.Value : string.Empty;
            }
    }
