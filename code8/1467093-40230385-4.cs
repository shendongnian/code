    protected void Application_Error(Object sender, EventArgs e)
    {
        // Get last error occurred
        var exception = Server.GetLastError();
    
        // catch unhandled exceptions
        if (exception is HttpUnhandledException)
        {
            // handle the error by ASP .NET itself
            Server.ClearError();
            
            // write status code handling
            HttpContext.Current.Response.WriteFile(Server.MapPath("~/error.html"));
            HttpContext.Current.Response.StatusCode = 500;
            HttpContext.Current.Response.StatusDescription = "Internal Server Error";
    
            // set ASP .NET handlers instead of using IIS handlers
            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
        }
    }
