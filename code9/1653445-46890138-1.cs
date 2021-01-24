    using(PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "Fabrikam", "ou=TechWriters,dc=fabrikam,dc=com"))
    {
    
     UserPrincipal user = new UserPrincipal(ctx, userName, userPassword, true);
    
        // assign some properties to the user principal
        user.GivenName = "User";
        user.Surname = "One";
    
        // force the user to change password at next logon
        user.ExpirePasswordNow();
    
        // save the user to the directory
        user.Save();
    }
