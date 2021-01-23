    public string GetUserName()
    {
        string name = "";
        using (var context = new PrincipalContext(ContextType.Domain))
        {
            var usr = UserPrincipal.Current;
            if (usr != null)
            {
                name = usr.DisplayName;
            }
        }
    }
