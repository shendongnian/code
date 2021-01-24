    public static class IdentityExtensions {
        public static bool IsInGroup(this IIdentity identity, string group) {
           // how would i do the check here???
           if(identity != null) {
                var claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity != null) {
                    return claimsIdentity
                        .FindAll(Constants.Security.ClaimTypes.Groups)
                        .Any(claim => claim.Value == group);
                }
           }
           return false;
        }
    }
