    public static StringCollection GetGroupMembers(DomainType eDomainType, string strGroup)
    {
        DirectoryEntry de = new DirectoryEntry(adDSADPath);
        System.Collections.Specialized.StringCollection GroupMembers = new System.Collections.Specialized.StringCollection();
    ...
    }
