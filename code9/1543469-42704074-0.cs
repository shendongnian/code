    protected void Application_Error()
    {
        var lastError = Server.GetLastError() as HttpRequestValidationException;
        if (lastError == null)
            return;
        MvcHandler mvcHandler = Context.CurrentHandler as MvcHandler;
        if (mvcHandler == null)
            return;
        RequestContext requestContext = mvcHandler.RequestContext;
        if (requestContext == null)
            return;
        Server.ClearError();
        Response.Clear();
        Response.TrySkipIisCustomErrors = true;
        // pick one of the following two options, or maybe more?
        RedirectToUrl(requestContext);
        ExecuteActionResult(requestContext, ...);
    }
    void ExecuteActionResult(RequestContext requestContext, ActionResult result)
    {
        string controllerName = requestContext.RouteData.GetRequiredString("controller");
        IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
        IController controller = factory.CreateController(requestContext, controllerName);
        ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);
        result.ExecuteResult(controllerContext);
    }
    void RedirectToUrl(RequestContext requestContext)
    {
        requestContext.HttpContext.Server.TransferRequest($"~/Error/Something", false);
    }
