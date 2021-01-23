    private void ExecuteErrorAction(string action, HttpContextWrapper httpContext, Exception exception)
    {
        var routeData = new RouteData();
        routeData.Values["controller"] = "Error";
        routeData.Values["action"] = action;
        routeData.Values["exception"] = exception;
        IController errorController = DependencyResolver.Current.GetService<ErrorController>();
        var context = new RequestContext(httpContext, routeData);
        errorController.Execute(context);
    }
