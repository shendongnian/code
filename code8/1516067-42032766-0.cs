        public StringBuilder FindDisabledAccount(int sinceDay)
        {
            StringBuilder sb = new StringBuilder();
            DateTime fromDate = DateTime.Today.AddDays(-sinceDay);
            try
            {
                using (DirectorySearcher dSearch = new DirectorySearcher())
                {
                    dSearch.PageSize = 100;
                    dSearch.CacheResults = false;
    
                    string fromDateStr = fromDate.Year.ToString() + fromDate.Month.ToString("D2") + fromDate.Day.ToString("D2") + "000000.0Z";
                    string toDateStr = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString("D2") + (DateTime.Today.Day + 1).ToString("D2") + "000000.0Z";
    
                    dSearch.Filter = "(&(objectCategory=person)(objectClass=user)(userAccountControl:1.2.840.113556.1.4.803:=2)"
                     + "(whenChanged>=" + fromDateStr + ")(whenChanged<=" + toDateStr + "))";
    
                    dSearch.PropertiesToLoad.Add("sAMAccountName");
                    dSearch.PropertiesToLoad.Add("DisplayName");
                    dSearch.PropertiesToLoad.Add("mail");
                    dSearch.PropertiesToLoad.Add("distinguishedName");
                    dSearch.PropertiesToLoad.Add("whenChanged");
    
                    using (var sResult = dSearch.FindAll())
                    {
                        sb.AppendLine("EmpId,Name,Email,IsActive,LastChangedDate");
                        foreach (SearchResult result in sResult)
                        {
                            DirectoryEntry de = result.GetDirectoryEntry();
                            sb.AppendLine(de.Properties["sAMAccountName"].Value + "," + de.Properties["DisplayName"].Value + "," + de.Properties["mail"].Value + ",FALSE," + de.Properties["whenChanged"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sb;
        }
