    public class OwnAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Your auth code
    
            // If you need base functionality
            base.OnAuthorization(filterContext);
        }
    }
