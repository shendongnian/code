    public class DenyAttribute : AuthorizeAttribute 
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return !base.AuthorizeCore(httpContext);
        }
    }
