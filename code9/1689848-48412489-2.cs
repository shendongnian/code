    public class LoadApiKeys : ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var apiKey = "G12345";
            //to do : Read from db instead of hard coded value
            filterContext.Controller.ViewBag.GoogleApiKey =apiKey;
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
