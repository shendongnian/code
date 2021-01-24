    public bool AuthenticateUser1(UserLogin userLogin)
    {
        using (HalifaxDatabaseEntities db = new HalifaxDatabaseEntities())
        {
            var Totalcount = 0;
            int RetryAttempts = 4;
            if (db.tblUsers
               .Any(x => x.Username == userLogin.Username &&
                         x.Password == userLogin.Password && 
                         x.RetryAttempts <= RetryAttempts))
                        {
                            return true;
                        }
                TotalCount++;
                return false;
        }
    }
