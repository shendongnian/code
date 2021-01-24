    protected void Application_Error()
    {
        if (httpContext.AllErrors != null)
        {
            // you can handle message 
            var message = HttpUtility.HtmlEncode(httpContext.AllErrors[0]);
            //you can redirect ugly server error page to the one you created
            httpContext.Response.Redirect($"~/Error/Global");
        }
    }
