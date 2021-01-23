    using(myPersonalModelContext ctx = new myContext())
    {
        var notProcessedLogins = ctx.LogIns.Where(login => login.processed == false); 
        foreach (LogIn notProcessedLogin in notProcessedLogins)
        {
            notProcessedLogin.processed = true;
        }
        int notProcessedLoginsCounter = ctx.LogIns.Where(login => login.processed == false).Count(); 
        ctx.SubmitChanges(); 
        int notProcessedLoginsCounter = ctx.LogIns.Where(login => login.processed == false).Count();
    }
