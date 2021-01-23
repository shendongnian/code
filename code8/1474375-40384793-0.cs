    protected void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
       // Log exception to database if you want to.
    
        // Process 404 HTTP errors
        var httpException = exception as HttpException;
        if (httpException != null && httpException.GetHttpCode() == 404)
        {
            Response.Clear();
            Server.ClearError();
            Response.TrySkipIisCustomErrors = true;
    
            IController controller = new ErrorController();
    
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "NotFound");
    
            var requestContext = new RequestContext(
                 new HttpContextWrapper(Context), routeData);
            controller.Execute(requestContext);
        }
    }
