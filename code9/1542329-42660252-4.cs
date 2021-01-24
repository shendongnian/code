     public static DirectoryEntry GetUserDirectoryEntryFromCurrentDomain(string userDomainAndName)
        {
            var Split = userDomainAndName.Split(@"\\".ToCharArray());
            var DomainNetBiosNAme = Split[0];
            var UserName = Split[1];
            var QueryString = $"(&(objectCategory=person)(objectClass=user)(sAMAccountName={UserName}))";
            string netBIOSName = "";
            DirectoryEntry rootDSE = GetDirectoryObject(
                "LDAP://" + DomainNetBiosNAme + "/rootDSE");
            string domain = "LDAP://" + (string)rootDSE.Properties[
                "defaultNamingContext"][0];
            var Searcher = new DirectorySearcher(new DirectoryEntry(domain), QueryString);
            var  Result = Searcher.FindOne();
            var tReturn = Result.GetDirectoryEntry();
            Result.prop
            return tReturn; 
        }
