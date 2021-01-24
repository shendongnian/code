    public static class IdentityExtensions {
        public static bool IsInProjectGroup(this IIdentity identity, int projectId) {
           // how would i do the check here???
           if(identity != null) {
                var claimsIdentity = identity as ClaimsIdentity;
                if (claimsIdentity != null) {
                    return claimsIdentity
                        .FindAll(Constants.Security.ClaimTypes.ProjectGroups)
                        .Any(claim => claim.Value == projectId.ToString());
                }
           }
           return false;
        }
    }
