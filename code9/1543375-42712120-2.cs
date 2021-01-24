    const string accountName = "name"; // The accountName of AD user
    var principalContext = new PrincipalContext(ContextType.Domain, "domainNameHere", "AdminUser", "AdminPass");
    var userPrincipal = UserPrincipal.FindByIdentity(principalContext, accountName);
    
    if (userPrincipal != null)
    {
    	var dirEntry = userPrincipal.GetUnderlyingObject() as DirectoryEntry;
    	var status = IsAccountDisabled(dirEntry);
    	
    }
    //Jugde if it is disabled in AD
    public static bool IsAccountDisabled(DirectoryEntry user)
    {
            const string uac = "userAccountControl";
            if (user.NativeGuid == null) return false;
    
            if (user.Properties[uac] != null && user.Properties[uac].Value != null)
            {
                var userFlags = (UserFlags)user.Properties[uac].Value;
                return userFlags.Contains(UserFlags.AccountDisabled);
            }
    
            return false;
    }
