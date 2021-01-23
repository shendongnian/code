    var context = new PrincipalContext(ContextType.Domain,"Domain");
    var userPrincipal = UserPrincipal.FindByIdentity(
                                       context,
                                       IdentityType.SamAccountName,
                                       httpContext.User.Identity.Name);
               
    if (userPrincipal != null)
    {
        var principalGroups = userPrincipal.GetAuthorizationGroups();
        foreach (var principalGroup in principalGroups)
        {
            foreach (var group in groups)
            {
                if (String.Equals(
                    principalGroup.Name,
                    group,
                    StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
        }
    }
