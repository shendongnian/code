    public class AuthenticationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // Your validation logic here.
        }
    }
