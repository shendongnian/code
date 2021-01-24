    public class CustomActionFilter : ActionFilterAttribute
        {
           
            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                filterContext.Controller.ViewBag.StartupScript = "Message you want to pass after action has been executed";
            }        
        }
