    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception; 
            context.Response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            context.Response.Content = new StringContent(exception.Message);
        }
    }
