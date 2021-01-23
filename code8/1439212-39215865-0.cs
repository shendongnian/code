    using System.DirectoryServices.AccountManagement;
    string fullName = null;
    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
    {
        using (UserPrincipal user = UserPrincipal.FindByIdentity(context,"hajani"))
        {
            if (user != null)
            {
                fullName = user.DisplayName;
                lbl_Login.Text = fullName;
            }
        }
    }
    
