     public List<string> GetUsersActiveDirectoryGroups(string windowsUserName)
     {
                var allUserGroups = new List<string>();
                var domainConnection = new DirectoryEntry();
    
                var samSearcher = new DirectorySearcher
                {
                    SearchRoot = domainConnection,
                    Filter = "(samAccountName=" + windowsUserName + ")"
                };
                samSearcher.PropertiesToLoad.Add("displayName");
    
                var samResult = samSearcher.FindOne();
    
                if (samResult == null) //User not found
                    return allUserGroups;
    
                //Get groups
                var theUser = samResult.GetDirectoryEntry();
                theUser.RefreshCache(new[] {"tokenGroups"});
    
                foreach (byte[] resultBytes in theUser.Properties["tokenGroups"])
                {
                    var mySid = new SecurityIdentifier(resultBytes, 0);
    
                    var sidSearcher = new DirectorySearcher
                    {
                        SearchRoot = domainConnection,
                        Filter = "(objectSid=" + mySid.Value + ")"
                    };
                    sidSearcher.PropertiesToLoad.Add("name");
    
                    var sidResult = sidSearcher.FindOne();
                    if (sidResult != null)
                    {
                        allUserGroups.Add(sidResult.Properties["name"][0].ToString());
                    }
                }
    
                return allUserGroups;
    }
