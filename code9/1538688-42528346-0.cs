     protected void Application_Error()
     {
        Exception exception = Server.GetLastError();
        Response.Clear();
        Server.ClearError();
        HttpException ex = exception as HttpException;
        var test = ex.GetHttpCode();
    }
