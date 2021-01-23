    protected void Application_Error(object sender, EventArgs e)
    {
        var exception = Server.GetLastError();
        
        var httpContext = new HttpContextWrapper(Context);
        httpContext.ClearError();
        var routeData = new RouteData();
        routeData.Values["controller"] = "Error";
        routeData.Values["action"] = "Index";
        routeData.Values["exception"] = exception;
        // Here you can add additional route values as necessary.
        // Make sure you add them as parameters to the action you're executing
        IController errorController = DependencyResolver.Current.GetService<ErrorController>();
        var context = new RequestContext(httpContext, routeData);
        errorController.Execute(context);
    }
