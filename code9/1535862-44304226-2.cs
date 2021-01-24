    public class ValidateMimeMultipartContentFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
        }
    
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
    
        }
    
    }
