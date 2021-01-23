    protected void Application_Error(object sender, EventArgs e)
    {
        Exception exception = Server.GetLastError();
        // Do something with the error.
        System.Diagnostics.Debug.WriteLine(exception);
        
        // Redirect somewhere or return an error code in case of web api
        Response.Redirect("/Home/Error");
    }
