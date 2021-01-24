    public class CustomFilterAttribute : HandleErrorAttribute
    { 
        public override void OnException(ExceptionContext filterContext)
        {
             if(filterContext.Exception is HttpRequestValidationException)
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary{
                        { "action", "UnsafeRequest" },
                        { "controller", "Error" }
                    });
            }
        }
    }
