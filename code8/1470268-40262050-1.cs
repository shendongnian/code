    private static void DisableADUserUsingUserAccountControl(string username)
    {
        try
        {
            DirectoryEntry domainEntry = Domain.GetCurrentDomain().GetDirectoryEntry();
            // ldap filter
            string searchFilter = string.Format(@"(&(objectCategory=person)(objectClass=user)
                  (!sAMAccountType=805306370)(|(userPrincipalName={0})(sAMAccountName={0})))", username);
 
            DirectorySearcher searcher = new DirectorySearcher(domainEntry, searchFilter);
            SearchResult searchResult = searcher.FindOne();
            if (searcher != null)
            {
                DirectoryEntry userEntry = searchResult.GetDirectoryEntry();
 
                int old_UAC = (int)userEntry.Properties["userAccountControl"][0];
 
                // AD user account disable flag
                int ADS_UF_ACCOUNTDISABLE = 2;
 
                // To disable an ad user account, we need to set the disable bit/flag:
                userEntry.Properties["userAccountControl"][0] = (old_UAC | ADS_UF_ACCOUNTDISABLE);
                userEntry.CommitChanges();
 
                Console.WriteLine("Active Director User Account Disabled successfully 
                                    through userAccountControl property");
            }
            else
            {
                //AD User Not Found
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
