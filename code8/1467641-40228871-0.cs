   protected void Application_Error()
   {
    Exception exception = Server.GetLastError();
    var httpException = exception as HttpException;
    Response.Clear();
    Server.ClearError();
    var routeData = new RouteData();
    routeData.Values["controller"] = "Errors";
    routeData.Values["action"] = "Common";
    routeData.Values["exception"] = exception;
    Response.StatusCode = 500;
    if (httpException != null)
    {
      Response.StatusCode = httpException.GetHttpCode();
      switch (Response.StatusCode)
    {
      case 403:
        routeData.Values["action"] = "Http403";
        break;
      case 404:
        routeData.Values["action"] = "Http404";
        break;
      case 400:
        routeData.Values["action"] = "Http400";
        break;
      }
    }
    Response.TrySkipIisCustomErrors = true;
    IController errorsController = new ErrorsController();
    var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
    /* This will run specific action without redirecting */
    errorsController.Execute(rc);
}
