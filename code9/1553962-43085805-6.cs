    // Private Method
    private static void DiableADUserUsingUserPrincipal(string username)
    {
    	try
    	{
    		PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
    		UserPrincipal userPrincipal = UserPrincipal.FindByIdentity
    				(principalContext, username);
    		userPrincipal.Enabled = false;
    		userPrincipal.Save();
    
    		MessageBox.Show("AD Account disabled for {0}", username);
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
