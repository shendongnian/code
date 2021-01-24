    public class Custom_ExceptionAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        var routeData = new RouteValueDictionary(new {
                          controller = "Error",
                          action = "Test_Error",
                          id = 1,
                       });
        filterContext.ExceptionHandled = true;
        filterContext.Result = new RedirectToRouteResult(routeData);
        filterContext.Result.ExecuteResultAsync(filterContext);
    }
