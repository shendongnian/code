    public class AdminManagerAuthorizationOverrideOthers : RolesAuthorizationRequirement
    {
        public AdminManagerAuthorizationOverrideOthers(IEnumerable<string> allowedRoles) : base(allowedRoles)
        {
        }
    }
