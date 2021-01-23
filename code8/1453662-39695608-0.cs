    public class SessionAuthAttribute : AuthorizeAttribute
        {
            public SessionAuthAttribute() { }
    
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                //base.OnAuthorization(filterContext);
                var userID = filterContext.HttpContext.Session["username"];
                if (userID == null)
                {
                    filterContext.Result = new RedirectResult("/Home");
                }
            }
    
            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                base.HandleUnauthorizedRequest(filterContext);
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Home",
                            action = "Index"
                        })
                        );
            }
        }
