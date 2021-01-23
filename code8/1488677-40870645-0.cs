    public class SomeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CacheCurrentStep(filterContext.HttpContext.Request);
        }
        private static void CacheCurrentStep(HttpRequestBase request)
        {
            string url = request.Url.PathAndQuery;
            // Save it, however you do that
        }
    }
