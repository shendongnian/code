    public class MyAuthorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.Result = new ContentResult() { Content = "You don't have rights to take actions" };
        }
    }
