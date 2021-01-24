    public class AjaxAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new AjaxHandler();
        }
    }
    public class AjaxHandler : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var response = httpContext.Response;
            if (request.IsAjaxRequest())
            {
                response.Clear();
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
                this.Data = new
                {
                    success = false,
                    resultMessage = "Errors"
                };
                this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                response.End();
            }
            else
            {
                var url = request.Url.AbsoluteUri;
                url = HttpUtility.UrlEncode(url);
                url = ConfigurationManager.AppSettings["LoginUrl"] + "?ReturnUrl=" + url;
                var redirectResult = new RedirectResult(url);
                redirectResult.ExecuteResult(context);
            }
        }
    }
