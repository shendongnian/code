    public static class GenericIdentityExtensions {
        const string ClientIdentifier = "oauth:client";
        /// <summary>
        /// Set the client id claim
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static bool SetClientId(this IIdentity identity, string clientId) {
            if (identity != null) {
                var claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity != null) {
                    claimsIdentity.AddClaim(new Claim(ClientIdentifier, clientId));
                    return true;
                }
            }
            return false;
        }        
        /// <summary>
        /// Return the client id claim
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetClientId(this IIdentity identity) {
            if (identity != null) {
                var claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity != null) {
                    return claimsIdentity.FindFirstOrEmpty(ClientIdentifier);
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Retrieves the first claim that is matched by the specified type if it exists, String.Empty otherwise.
        /// </summary>
        public static string FindFirstOrEmpty(this ClaimsIdentity identity, string claimType) {
            var claim = identity.FindFirst(claimType);
            return claim == null ? string.Empty : claim.Value;
        }
    }
