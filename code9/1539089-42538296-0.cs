    static Regex partComponentRegex = new Regex("^[^:]+:Win32_UserAccount.Domain=\"(?<Domain>.+?)\",Name=\"(?<Name>.+?)\"$");
    static IEnumerable<User> GetUsersFromSidType(WellKnownSidType wellKnownSidType)
    {
        string gName = GetGroupName(wellKnownSidType);
        using (ManagementObjectSearcher groupSearcher = new ManagementObjectSearcher(
            string.Format("SELECT * FROM Win32_GroupUser WHERE GroupComponent =\"Win32_Group.Domain='{0}',Name='{1}'\"",
            Environment.MachineName,
            gName)))
       {
            foreach (var group in groupSearcher.Get())
            {
                Match m = partComponentRegex.Match(group["PartComponent"].ToString());
                if (m.Success)
                {
                    using (ManagementObjectSearcher userSearcher = new ManagementObjectSearcher(
                        string.Format("SELECT * FROM Win32_UserAccount WHERE Name='{0}' AND Domain='{1}'",
                        m.Groups["Name"], m.Groups["Domain"])))
                    { 
                        foreach (var user in userSearcher.Get())
                        {
                            yield return new User()
                            {
                                Disabled = (bool)user["Disabled"],
                                Domain = user["Domain"].ToString(),
                                FullName = user["FullName"].ToString(),
                                Name = user["Name"].ToString(),
                                SID = user["SID"].ToString()
                            };
                        }
                    }
                }
            } 
        }
    }
    static string GetGroupName(WellKnownSidType wellKnownSidType)
    {
        SecurityIdentifier sid = new SecurityIdentifier(wellKnownSidType, null);
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(
            string.Format("SELECT * FROM Win32_Group WHERE SID='{0}'",
            sid.Value)))
        {
            var e = searcher.Get().GetEnumerator();
            if (e.MoveNext())
                return e.Current["Name"].ToString();
            return null;
        }
    }
