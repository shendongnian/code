    public static class GenericIdentityExtensions {
        /// <summary>
        /// Return the Email claim
        /// </summary>
        public static string GetEmail(this IIdentity identity) {
            if (identity != null && identity.IsAuthenticated) {
                ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity != null)
                    return claimsIdentity.FindFirstOrEmpty(Constants.Security.ClaimTypes.Email);
            }
            return string.Empty;
        }
        /// <summary>
        /// Return the Email2 claim
        /// </summary>
        public static string GetEmail2(this IIdentity identity) {
            if (identity != null && identity.IsAuthenticated) {
                ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity != null)
                    return claimsIdentity.FindFirstOrEmpty(Constants.Security.ClaimTypes.Email2);
            }
            return string.Empty;
        }
        /// <summary>
        /// Retrieves the first claim that is matched by the specified type if it exists, String.Empty otherwise.
        /// </summary>
        internal static string FindFirstOrEmpty(this ClaimsIdentity identity, string claimType) {
            var claim = identity.FindFirst(claimType);
            return claim == null ? string.Empty : claim.Value;
        }
    }
