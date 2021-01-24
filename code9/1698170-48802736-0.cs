    var path = String.Format("LDAP://{0}:{1}", DomainControllerIP, Port);
                    DirectoryEntry rootDE = new DirectoryEntry(path, strUserName, strPassword);
                    DirectorySearcher dSearcher = new DirectorySearcher(rootDE);
                    dSearcher.Filter = "(&(sAMAccountName=" + strUserName + ")(objectClass=User)(objectCategory=Person))";
                    SearchResult sResult = dSearcher.FindOne();
                    foreach (var grp in sResult.Properties["memberOf"])
                        {
                            string sGrpName = (Convert.ToString(grp).Remove(0, 3)).Split(',')[0];
                            DirectorySearcher gSearcher = new DirectorySearcher(rootDE);
                            gSearcher.Filter = "sAMAccountName=" + sGrpName;
                            SearchResult gResult = gSearcher.FindOne();
                            //Group Name in groupName
                            string groupName = gResult.Properties["name"][0].ToString();
                        }
