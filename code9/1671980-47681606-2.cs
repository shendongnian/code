    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
           
            if (filterContext.Exception == null) //Do something
            if(filterContext.ExceptionHandled == true) // Do something
            else // Do something else
            base.OnActionExecuted(filterContext);
        }
    }
