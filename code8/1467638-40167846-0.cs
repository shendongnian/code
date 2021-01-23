    private static string GetFullName()
    {
        try
        {
            DirectoryEntry de = new DirectoryEntry("WinNT://" + Environment.UserDomainName + "/" + Environment.UserName);
            var firstName = de.Properties["givenName"].Value.ToString();
            var lastName = de.Properties["sn"].Value.ToString();
            return string.Format("{0} {1}", firstName, lastName);
        }
        catch { return null; }
    }
