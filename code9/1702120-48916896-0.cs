    public static List<string> GetuPNSuffixes()
    {
        //add root domain
        List<string> suffixList = new List<string>();
        suffixList.Add(Domain.GetCurrentDomain().Name);
        //get the list of alternate domains
        DirectoryEntry rootDSE = new DirectoryEntry(@"LDAP://RootDSE");
        string context = rootDSE.Properties["configurationNamingContext"].Value.ToString();
        DirectoryEntry partition = new DirectoryEntry(@"LDAP://CN=Partitions," + context);
        foreach (string suffix in partition.Properties["uPNSuffixes"])
        {
            suffixList.Add(suffix);
        }
        return suffixList;
    }
