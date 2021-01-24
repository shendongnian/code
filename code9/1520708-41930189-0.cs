    private void BindSearchedUser(string Domain, string UserName)
    {
        try
        {
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, Domain);
        } 
        catch (PrincipalServerDownException ex)
        {
            // show your error message
            return;
        }
        ...
    }
