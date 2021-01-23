    private static void EnableADUserUsingUserPrincipal(string username)
    {
        try
        {                
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
 
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity
                    (principalContext, username);
 
            userPrincipal.Enabled = true;
 
            userPrincipal.Save();
 
            Console.WriteLine("Active Director User Account Enabled successfully through UserPrincipal");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
