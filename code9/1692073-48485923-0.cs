    using System.Web.Mvc;
    namespace WebApplication1.Filters
    {
        public class LangOverrideFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
            }
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                filterContext.RouteData.Values["lang"] = "en";
                //Access userclaims through filterContext.HttpContext.User.
            }
        }
    }
