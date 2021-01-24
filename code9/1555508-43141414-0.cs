    public bool ValidateCredentials(string userName, string password)
    {
    	userName = userName.EnsureNotNull();
    	userName = userName.Trim();
    
    	password = password.EnsureNotNull();
    	password = password.Trim();
    
    	using (var context = new PrincipalContext(ContextType.Domain))
    	{
    		return context.ValidateCredentials(userName, password);
    	}
    }
    
    public bool IsUserInAdGroup(string userName, string adGroupName)
    {
    	bool result = false;
    	userName = userName.EnsureNotNull();
    	userName = userName.Trim();
    
    	using (var context = new PrincipalContext(ContextType.Domain))
    	{
    		var user = UserPrincipal.FindByIdentity(context, userName);
    		if (user != null)
    		{
    			var group = GroupPrincipal.FindByIdentity(context, adGroupName);
    			if (group != null)
    			{
    				if (user.IsMemberOf(group))
    				{
    					result = true;
    				}
    			}
    		}
    	}
    	return result;
    }
