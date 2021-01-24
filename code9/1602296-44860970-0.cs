            string domainUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] paramsLogin = domainUser.Split('\\');
            
            string domain = paramsLogin[0].ToString();
            string LdapPath = "";
            string strDomainPath = DomainPath();
            LdapPath = string.Format("LDAP://{0}/{1}", DomainName, strDomainPath);
            string username = LoginUser.UserName;
            string password = LoginUser.Password;           
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    IsLoginSucess = true;
                    //Do your stuff here
                }
                // Update the new path to the user in the directory
                LdapPath = result.Path;
                string _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                IsLoginSucess = false;                
            }
