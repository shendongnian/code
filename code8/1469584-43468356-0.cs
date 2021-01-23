    public DataTable FindPersons(string lname, string fname)
        { 
    
            DirectorySearcher searcher = new DirectorySearcher();
            searcher.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(givenname={0}*)(sn={1}*))", fname, lname);
    
            SearchResultCollection allResults;
            allResults = searcher.FindAll();
    
            DataTable dt = new DataTable();
            dt.Columns.Add("DisplayName", typeof(string));
            dt.Columns.Add("GivenName", typeof(string));
            dt.Columns.Add("SurName", typeof(string));
            dt.Columns.Add("MSID", typeof(string));
            if (allResults.Count >= 0)
            { 
                for (int i = 0; i < allResults.Count; i++)
                {
                    DirectoryEntry deMembershipUser = allResults[i].GetDirectoryEntry();
                    deMembershipUser.RefreshCache(); 
    
                    dt.Rows.Add(
                        (string)deMembershipUser.Properties["displayname"].Value, 
                        (string)deMembershipUser.Properties["givenName"].Value,
                        (string)deMembershipUser.Properties["sn"].Value, 
                        (string)deMembershipUser.Properties["cn"].Value
                        ); 
                } 
            } 
            return dt;
        }
