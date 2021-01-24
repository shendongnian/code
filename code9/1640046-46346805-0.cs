    public bool ValidateCredentials(string domain, string username, string password)
    {
        using (var context = new PrincipalContext(ContextType.Domain, domain))
        {
            return context.ValidateCredentials(username, password);
        }
    }
    
    public bool IsUserInAdGroup(string domain, string username, string adGroupName)
    {
        bool result = false;
        using (var context = new PrincipalContext(ContextType.Domain, domain))
        {
            var user = UserPrincipal.FindByIdentity(context, username);
            if (user != null)
            {
                var group = GroupPrincipal.FindByIdentity(context, adGroupName);
                if (group != null && user.IsMemberOf(group))
                    result = true;
            }
        }
        return result;
    }
