    public static Boolean Authenticate(String password)
    {
        String user = WindowsIdentity.GetCurrent().Name; //Should be: DomainName\UserName
        String[] DomainAndUserName = user.Split(new Char[] { '\\' }, 2);
        if (DomainAndUserName.Length != 2) { return false; } // No DomainName ==> Wrong network;
        using (PrincipalContext PrincipalContext = new PrincipalContext(ContextType.Domain, DomainAndUserName[0]))
        {
                return PrincipalContext.ValidateCredentials(DomainAndUserName[1], password);
        }
    }
