    public class CheckMyPostDataFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            XyzModel model = (XyzModel )actionContext.ActionParameters["model"]; // you will get data here 
    
            base.OnActionExecuting(actionContext);
        }
    }
