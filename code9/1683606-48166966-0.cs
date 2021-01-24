    public class AddHeadersFilterAttribute: ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        filterContext.HttpContext.Response.AddHeader("header", "headerValue");
 
        base.OnActionExecuting(filterContext);
      }
    }
