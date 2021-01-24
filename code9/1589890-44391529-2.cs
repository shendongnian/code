    public class VariableCheckerValidationAttribute : ValidationAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext 
        filterContext)
        {
            if(filterContext.HttpContext.Session["myVariable"] == null)
            {
                filterContext.Result = RedirectToAction("/../Cons/SetVariable"‌​) RedirectToAction("/../Cons/SetVariable");
            }
        }
    }
