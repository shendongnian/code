    namespace PubManager.Authorisation
    {
        public class AuthoriseByRoleAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var isAuthorized = base.AuthorizeCore(httpContext);
                if (!isAuthorized && httpContext.Request.IsAjaxRequest())
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.End();
                }
                if (isAuthorized)
                {
                    var request = httpContext.Request;
                    var r = request.RequestContext.RouteData.Values["r"]
                        ?? request["r"];
                    var currentUser = (UserModel) HttpContext.Current.Session["user"];
                    if (currentUser == null)
                    {
                        currentUser = HttpContext.Current.User.GetWebUser();
                    }
                    var rd = httpContext.Request.RequestContext.RouteData;
                    string currentAction = rd.GetRequiredString("action");
                    string currentController = rd.GetRequiredString("controller");
                    if (currentUser.HasAccess(currentController, currentAction))
                        return true;
                }
                httpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return false;
            }
        }
    }
