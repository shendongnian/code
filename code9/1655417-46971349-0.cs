      public void SetAdInfo(string objectFilter, Property objectName, 
                string objectValue, string LdapDomain)
      {
        string connectionPrefix = "LDAP://" + LdapDomain;
        DirectoryEntry entry = new DirectoryEntry(connectionPrefix);
        DirectorySearcher mySearcher = new DirectorySearcher(entry);
        mySearcher.Filter = "(cn=" + objectFilter + ")";
        mySearcher.PropertiesToLoad.Add(""+objectName+"");
        SearchResult result = mySearcher.FindOne();
        if (result != null)
        {
            DirectoryEntry entryToUpdate = result.GetDirectoryEntry();
            if (!(String.IsNullOrEmpty(objectValue)))
            {
                if (result.Properties.Contains("" + objectName + ""))
                {
                    entryToUpdate.Properties["" + objectName + ""].Value = objectValue;
                }
                else
                {
                    entryToUpdate.Properties["" + objectName + ""].Add(objectValue);
                }
                entryToUpdate.CommitChanges();
            }
        }
        entry.Close();
        entry.Dispose();
        mySearcher.Dispose();
    }
