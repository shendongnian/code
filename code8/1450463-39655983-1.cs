    Public void RefreshSession()
    {
        //your session reset from this line, as i know you don't have to write any code here.
    }
    public bool LogOut()
    {
            LogOff();
            return true;
    }
    void LogOut()
    {       
        Session.Clear();
        Session.Abandon();
        Session.RemoveAll();
        ClearCache();        
    }
    
    void ClearCache()
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
        ////FormsAuthentication.SignOut();
    }
