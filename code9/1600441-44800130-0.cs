    You can use very simple approach here.
    You can use  **Application_Error()** events and write it in **Global.asax** 
    file.Its called automatically whenever system generates any type of error
    Note : Create "ErrorController" and inside that make one view with name 
    "Errors.cshtml"
    protected void  Application_Error(object sender, EventArgs e)
    {
            if (null != Context && null != Context.AllErrors)
            {
                Exception exception = Server.GetLastError().GetBaseException();
	              RouteData routeData = new RouteData();
                    routeData.Values.Add("controller", "Error");
                    if (exception == null)
                    {
                        routeData.Values.Add("action", "Index");
                    }
                    else
                    {
                        routeData.Values.Add("action", "Errors");
                        routeData.Values.Add("exceptionValue", exception);
                    }
                    Response.TrySkipIisCustomErrors = true;
                    IController errorController = new ErrorsController();
                    errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                }
  
      }
