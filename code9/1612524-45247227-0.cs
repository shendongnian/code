    public class AuthorizeByActiveDirectoryGroupsAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var roles = Roles.Split(",");
            using (var domainContext = new PrincipalContext(ContextType.Domain))
            {
                using (var domainUser = UserPrincipal.FindByIdentity(domainContext, httpContext.User.Identity.Name))
                {
                    var groups = domainUser.GetAuthorizationGroups();
                    return groups
                        .Select(x => x.Name) // the group name
                        .Any(x => roles.Contains(x)); // any group is one of the specified in the Roles property of the attribute
                }
            }
        }
    }
