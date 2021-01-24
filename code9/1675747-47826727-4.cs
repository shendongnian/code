    public class LoggingAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting
          (System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                //Logger.Log();
            }
    
       public override void OnActionExecuted(HttpActionExecutedContext httpContext)
            {
                //Logger.Log();
            }
    }
