    public class VisitCountAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // add visit count
            VisitCount();
            base.OnActionExecuting(filterContext);
        }
    }
