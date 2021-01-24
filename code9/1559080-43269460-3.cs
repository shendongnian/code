    public class CustomActionFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.StartupScript = "Your Message Goes here";
            base.OnActionExecuted(filterContext);
        }
    }
