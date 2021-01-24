     public static class IdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst(x => x.Type.ToLowerInvariant().Contains("nameidentifier"));
            // Test for null to avoid issues during local testing
            return claim != null ? Guid.Parse(claim.Value) : throw new ArgumentNullException(nameof(claim));
        }
    }
