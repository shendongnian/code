    public static StringCollection GetGroupMembers(DomainType eDomainType, string strGroup)
    {
        using (System.Web.Hosting.HostingEnvironment.Impersonate())
        {
            DirectoryEntry de = new DirectoryEntry(adDSADPath);
            System.Collections.Specialized.StringCollection GroupMembers = new System.Collections.Specialized.StringCollection();
            ...
        }
    }
