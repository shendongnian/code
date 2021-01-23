     private static void EnableADUserUsingUserPrincipal(string username)
         {
           try
        {                
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);
 
            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity
                    (principalContext, username);
 
            userPrincipal.Enabled = true;
 
            userPrincipal.Save();
 
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
     }
