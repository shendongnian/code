    public class YourFilterName : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // pre-processing
            //Your authentication logic goes here - use actionContext
        }
 
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }
 
            Debug.WriteLine("OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
        }
    }
