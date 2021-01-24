     public class SessionCheck: ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpSessionStateBase session = filterContext.HttpContext.Session;
                if (session != null && session["UserInfo"] == null)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                                    { "Controller", "Users" },
                                    { "Action", "Login" }
                                    });
                }
            }
        } 
