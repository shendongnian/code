    protected void Application_Error(object sender, EventArgs e)
    {
        // Get the exception object.
        Exception exc = Server.GetLastError();
        if (exc.GetType() == typeof(HttpException))
        {
            if (exc.Message.Contains("Maximum request length exceeded."))
                Response.Redirect(String.Format("~/Error/RequestLengthExceeded"));
        }
        Server.ClearError();
    }
