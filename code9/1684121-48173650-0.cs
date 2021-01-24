    public class IdCheck : FilterAttribute, IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                if (filterContext.HttpContext.Session["UserId"] == null)
                {
                    filterContext.Result = new RedirectResult("/");
                }
            }
        }
