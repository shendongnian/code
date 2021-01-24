    using Novell.Directory.Ldap;
    try
    {
        var conn = new LdapConnection();
        conn.Connect(domain, 389);
        conn.Bind(LdapConnection.Ldap_V3, $"{subDomain}\\{username}", password);
        return true;
    }
    catch (LdapException ex)
    {
        Console.WriteLine(ex.Message);
        return false;
    }
