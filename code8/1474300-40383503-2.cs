    public static void Test4()
    {
        System.Net.NetworkInformation.IPGlobalProperties ipgp = 
            System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties();
        
        // IDnsResolver resolver = new RecursiveDnsResolver(); // Warning: Doesn't work
        IDnsResolver resolver = new DnsStubResolver();
        List<SrvRecord> srvRecords = resolver.Resolve<SrvRecord>("_ldap._tcp." + ipgp.DomainName, RecordType.Srv);
        foreach (SrvRecord thisRecord in srvRecords)
        {
            // System.Console.WriteLine(thisRecord.Name);
            System.Console.WriteLine(thisRecord.Target);
            System.Console.WriteLine(thisRecord.Port);
            string url = "LDAP://" + thisRecord.Target + ":" + thisRecord.Port; // Note: OR LDAPS:// - but Novell doesn't want these parts anyway 
            System.Console.WriteLine(url);
        } // Next thisRecord
    }
