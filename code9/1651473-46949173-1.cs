    private void Search()
    {
        // GetDefaultDomain as start point is optional, you can also pass a specific 
        // root object like new DirectoryEntry ("LDAP://OU=myOrganisation,DC=myCompany,DC=com");
        // not sure if GetDefaultDomain() works in B2C though :(
        var results = FindUser("extPropName", "ValueYouAreLookingFor", GetDefaultDomain());
        foreach (SearchResult sr in results)
        {
            // query the other properties you want for example Accountname
            Console.WriteLine(sr.Properties["sAMAccountName"][0].ToString());
        }
        Console.ReadKey();
    }
    private DirectoryEntry GetDefaultDomain()
    {   // Find the default domain
        using (var dom = new DirectoryEntry("LDAP://rootDSE"))
        {
            return new DirectoryEntry("LDAP://" + dom.Properties["defaultNamingContext"][0].ToString());
        }
    }
    private SearchResultCollection FindUser(string extPropName, string searchValue, DirectoryEntry startNode)
    {
        using (DirectorySearcher dsSearcher = new DirectorySearcher(startNode))
        {
            dsSearcher.Filter = $"(&(objectClass=user)({extPropName}={searchValue}))";
            return dsSearcher.FindAll();
        }
    }
