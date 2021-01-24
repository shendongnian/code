    public bool LDAPAuthenticateUser(LDAPSpecification spec)
    {
        string pathDomain = string.Format("LDAP://{0}", spec.Path);
        if (!string.IsNullOrEmpty(spec.Domain))
            pathDomain += string.Format("/{0}", spec.Domain);
        DirectoryEntry entry = new DirectoryEntry(pathDomain, spec.UserName, spec.Password, AuthenticationTypes.Secure);
        try
        {
            //Bind to the native AdsObject to force authentication.
            object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
    
            search.Filter = "(SAMAccountName=" + spec.UserName + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Logging.Log(LoggingMode.Error, "Error authenticating user on LDAP , PATH:{0} , UserName:{1}, EXP:{2}", pathDomain, spec.UserName, ex.ToString());
            return false;
        }
        return true;
    }
