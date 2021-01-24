    public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var req = HttpContext.Current.Request.InputStream;
            string body = new StreamReader(req).ReadToEnd();
        }
    }
