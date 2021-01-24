    protected void Application_Error(object sender, EventArgs e)
    {
        if(Context.Request.RawUrl.Contains("*"))
        {
            Server.ClearError();
        }
    }
    
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if(!Context.Request.RawUrl.Contains("*"))
        {
            return;
        }
    
        var newPath = Context.Request.RawUrl.Replace("*", "");
        base.Context.RewritePath(newPath);
    }
