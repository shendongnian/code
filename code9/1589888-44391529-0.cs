    public class VariableCheckerValidationAttribute : ValidationAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext 
        filterContext)
        {
            if(filterContext.HttpContext.Session["myVariable"] == null)
            {
                return RedirectToAction("/../Cons/SetVariable");
            }
        }
    }
