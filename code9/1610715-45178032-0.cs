    public class MyCustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var claimsIdentity = System.Web.HttpContext.Current.User.Identity as ClaimsIdentity;
            var userName = claimsIdentity.FindFirst("email")?.Value;
            return _uow.PagePermissions.CheckPagePermission(new pagePermission { /*whatever you are passing here.*/ });
        }
    }
