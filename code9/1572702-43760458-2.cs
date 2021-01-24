    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
    
            //    return httpContext.Session != null && httpContext.Session.Count != 0;
            return isAuthorized;
    
        }
    
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(LoginRougte());
                }
    
            }
            else if (!Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
            {
    
                filterContext.Result = new HttpUnauthorizedResult();
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"action", "Index"},
                        {"controller", "Login"},
                        {"area", ""}
                    });
                    filterContext.Result = new RedirectToRouteResult(LoginRougte());
                }
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
    
    
        }
    
        private RouteValueDictionary LoginRougte()
        {
            return new RouteValueDictionary
                        {
                            {"action", "Index"},
                            {"controller", "Login"},
                            {"area", ""}
                        };
        }
    }
