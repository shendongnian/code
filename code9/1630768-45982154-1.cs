    public class UserFriendlyExceptionFilterAttribute: ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                var friendlyException = context.Exception as UserFriendlyException;
                if (friendlyException != null)
                {
                    context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new {Message = friendlyException.Message}); 
                }
            }
        }
