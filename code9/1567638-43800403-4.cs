    public static void InsertGroupDirectoryServices(string samAccountName)
    {
        DirectoryEntry groupEntry = new DirectoryEntry("LDAP://server.address/CN=PSO_PRODUCT_USER,OU=PSO_,OU=Groups,OU=_PRODUCT,DC=address,DC=server", "USERNAME", "PASSWORD");
        string userDn = String.Concat("LDAP://server.address/CN=", samAccountName, ",OU=Users,OU=_PRODUCT,DC=address,DC=server");
        DirectoryEntry userEntry = new DirectoryEntry(userDn, "USERNAME", "PASSWORD");
        groupEntry.Invoke("Add", new object[] { userDn });
        groupEntry.CommitChanges();            
        groupEntry.Invoke("Remove", new object[] { userDn });
        groupEntry.CommitChanges();            
        groupEntry.Close();
    }
