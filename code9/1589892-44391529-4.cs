    public class VariableCheckerValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext 
        filterContext)
        {
            if(filterContext.HttpContext.Session["myVariable"] == null)
            {
                filterContext.Result = new RedirectToRouteResult("/../Cons/SetVariable"‌, filterContext.RouteData.Values);
            }
        }
    }
