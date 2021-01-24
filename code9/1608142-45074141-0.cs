    public class UserNameAuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);
            dynamic user = HttpContext.Current.Session["user"];
            return user.name == "Admin";
        }
    }
