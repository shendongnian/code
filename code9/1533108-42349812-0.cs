     public class AccessDeniedAuthorizeAttribute : AuthorizeAttribute
     {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                base.OnAuthorization(filterContext);
                if (filterContext.Result is HttpUnauthorizedResult)
                {
                    // Perform your unauthorized action here.
                }
            }
    }
