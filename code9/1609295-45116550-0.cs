    public class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!actionContext.RequestContext.Principal.Identity.IsAuthenticated)
            {
                //Logic for when api not authenticated
            }
            base.HandleUnauthorizedRequest(actionContext);
        }
    }
