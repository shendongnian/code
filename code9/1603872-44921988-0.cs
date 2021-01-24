    public bool UserExists(string username)
    {
       // create your domain context
       using (PrincipalContext domain = new PrincipalContext(ContextType.Domain))
       {
           // find the user
           UserPrincipal foundUser = UserPrincipal.FindByIdentity(domain, IdentityType.Name, username);
    
           return foundUser != null;
        }
    }
