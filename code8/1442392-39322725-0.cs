    using (PrincipalContext context = new PrincipalContext(ContextType.Domain)) //pass in your domain as the second param if needed as well 
    {
        using (UserPrincipal user = UserPrincipal.FindByIdentity(context,"yourusernamehere"))
        {
            if (user != null)
            {
                fullName = user.DisplayName;
            }
        }
    }
