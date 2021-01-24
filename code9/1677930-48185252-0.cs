    public string FindUser(string activeDirectoryPath ,string userName, string password)
        {
            try
            {
                    using (var searcher = new DirectorySearcher(new DirectoryEntry(activeDirectoryPath, userName, password)))
                    {
                        searcher.Filter = string.Format("(&(objectClass=user)(name={0}))", userName);
                        searcher.PropertiesToLoad.Add("name");// username
                        var activeDirectoryStaff = searcher.FindOne();
                        if (activeDirectoryStaff != null)
                        {
                            return (string)activeDirectoryStaff.Properties["name"][0];
                        }
                        else
                            return null;
                    }
                }
                
            }
            catch (Exception ex)
            {
                this.Log().Error(ex, ex.Message);
                return null;
            }
            return null;
        }
