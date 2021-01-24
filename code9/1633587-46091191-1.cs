    public static IList<User> GetADUserDetails(string lastName)
    {
        SearchResultCollection resultCollection;
        SearchResult result;
        List<User> listADUsers = new List<User>();
        User listUsers = null;
    
        try
        {
            if (!string.IsNullOrEmpty(lastName))
            {
                // if `ConnectLdapActiveDirectory` method returns `DirectoryEntry`, you can use this assignment
                using (DirectoryEntry searchRoot = ConnectLdapActiveDirectory())
                {      
                    using (DirectorySearcher search = new DirectorySearcher(searchRoot))
                    {    
                        // do something                
                    }
                }
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            // do something
        }
    }
