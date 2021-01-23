    public abstract class BaseController : Controller
    {
      public override void OnActionExecuting(ActionExecutingContext context)
      {
        string apiKey = context.HttpContext.Request.Headers["key"];
        string httpMethod = context.HttpContext.Request.Method.ToUpper();
        string routeTemplate =context.ActionDescriptor.AttributeRouteInfo.Template;
        if (CheckAccess(apiKey, httpMethod , routeTemplate))
        {
           context.Result = Forbid();
        }
      }
    }
