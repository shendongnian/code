    protected void Application_Error(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        var exception = context.Server.GetLastError();
        if (exception is HttpRequestValidationException)
        {
    HttpContext.Current.Server.ClearError();
    HttpContext.Current.Response.Redirect("~/ErrorPage.aspx");
    
            return;
        }
    }
