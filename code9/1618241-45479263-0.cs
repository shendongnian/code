    public class InterceptionAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(HttpActionContext actionContext)
      {
        var x = "This is my custom line of code I need executed before any of the controller actions, for example log stuff";
        base.OnActionExecuting(actionContext);
      }
    }
