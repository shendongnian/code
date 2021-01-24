    /***********************************************
     * AuthorizeAttribute filter for JsonResult methods
     * 
     * Validates AntiForgeryToken from header of AJAX request.
     * AntiForgeryToken must be placed into that header.
     ************************************************/
    /*
     View
        @Html.AntiForgeryToken()
        <script>
            var headers = {};
            headers["__RequestVerificationToken"] = $('[name=__RequestVerificationToken]').val();
            $.ajax({
                type: "POST", //Type must be POST
                url: url,
                dataType: "json",
                headers: headers,
     
     Controller
        [ValidateJsonAntiForgeryToken]
        public JsonResult Method() { }
    */
    public sealed class ValidateJsonAntiForgeryToken : AuthorizeAttribute
    {
        public JsonResult deniedResult = new JsonResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            Data = new { StatusCode = HttpStatusCode.Forbidden, Error = "Access Denied" }
        };
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("ValidateJsonAntiForgeryToken");
            var request = filterContext.HttpContext.Request;
            if (request.HttpMethod == WebRequestMethods.Http.Post && request.IsAjaxRequest() && request.Headers["__RequestVerificationToken"] != null)
            {
                AntiForgery.Validate(CookieValue(request), request.Headers["__RequestVerificationToken"]);
            }
            else
            {
                filterContext.Result = deniedResult;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine("ValidateJsonAntiForgeryToken HandleUnauthorizedRequest ");
            filterContext.Result = deniedResult;
        }
        private static string CookieValue(HttpRequestBase request)
        {
            var cookie = request.Cookies[AntiForgeryConfig.CookieName];
            return cookie != null ? cookie.Value : null;
        }
    }
