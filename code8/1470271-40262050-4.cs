            UserPrincipal userPrincipal = UserPrincipal.FindByIdentity
                    (principalContext, username);
 
            userPrincipal.Enabled = false;
 
            userPrincipal.Save();
 
            Console.WriteLine("Active Director User Account Disabled successfully through UserPrincipal");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
