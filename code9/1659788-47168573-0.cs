    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated)
            {
                int httpCode = (int)System.Net.HttpStatusCode.Unauthorized;
                filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
                filterContext.HttpContext.Response.StatusCode = 200;
                filterContext.HttpContext.Response.ContentType = "application/json";
                filterContext.HttpContext.Response.Write(JsonConvert.SerializeObject(
                    new BaseResource(false, httpCode, "Request Forbidden. You must first login!")
                    )
                );
                filterContext.Result = new HttpStatusCodeResult(200);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }                
        }
    }
