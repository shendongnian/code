    bool dmainNotAvailable = false;
    PrincipalContext pcon = null;
    try
    {
    pcon = new PrincipalContext(ContextType.Domain, domain);
                                        
    }
    catch (System.DirectoryServices.AccountManagement.PrincipalServerDownException ex)
    {
       domainNotAvailable = true;
            
        try
        {
           pcon = new PrincipalContext(ContextType.Machine, Environment.MachineName);
        }
        catch (Exception ex2)
        {
           throw new Exception(ex2);
        }
    }
    string realUserName = !domainNotAvailable ? username : $"{domain}\\{username}";
    passwordOk = pcon.ValidateCredentials(realUserName, password);
