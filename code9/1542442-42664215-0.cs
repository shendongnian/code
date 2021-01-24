    public class CheckMyPostDataFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            XyzModel model = (XyzModel )actionContext.ActionArguments["model"]; // you will get data here 
    
            base.OnActionExecuting(actionContext);
        }
    }
