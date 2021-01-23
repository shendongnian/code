      public class ApiAuthAttribute : AuthorizeAttribute
      {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var urlHelper = new UrlHelper(filterContext.RequestContext);
                    filterContext.HttpContext.Response.StatusCode = 403;
                    filterContext.Result = new JsonResult
                    {
                        Data = new
                        {
                            Error = "NotAuthorized",
                            LogOnUrl = urlHelper.Action("AccessDenied", "Login")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
        
        }
    }
