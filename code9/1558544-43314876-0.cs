    public bool IsExpired(MembershipUser user, LoginModel model)
    {
        bool result = false;
        string ldap = ConfigurationManager.ConnectionStrings["ADConnectionString"].ConnectionString;
        DirectoryEntry rootEntry = new DirectoryEntry(ldap, model.UserName, model.Password, AuthenticationTypes.Secure);
        DirectorySearcher mySearcher = new DirectorySearcher(rootEntry);
        SearchResultCollection results;
        string filter = "maxPwdAge=*";
        mySearcher.Filter = filter;
        results = mySearcher.FindAll();
        long maxDays = 0;
        if (results.Count >= 1)
        {
            Int64 maxPwdAge = (Int64)results[0].Properties["maxPwdAge"][0];
            maxDays = maxPwdAge / -864000000000;
        }
        
        long daysLeft = 0;
        daysLeft = maxDays - DateTime.Today.Subtract(user.LastPasswordChangedDate).Days;
        if (daysLeft <0)
        {
            result = true;
        } else
        {
            if (daysLeft<=14)
            {
                this.Expiring = true;
                this.ExpiringString = String.Format("You must change your password within" + " {0} days", daysLeft);
            }       
            else
            {
                this.Expiring = false;
            }     
        }
        return result;
    }
