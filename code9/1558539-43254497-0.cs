    public override void Validate(string userName, string password)
    {
        if (userName == "test" && password == "test")        
            return;
        
        System.Threading.Thread.CurrentThread.Abort();
    }
