    using (var context = new PrincipalContext(ContextType.Domain))
    {
        var usr = UserPrincipal.FindByIdentity(context, User.Identity.Name); 
        if (usr != null)
           Console.WriteLine(usr.DisplayName);  
    }
