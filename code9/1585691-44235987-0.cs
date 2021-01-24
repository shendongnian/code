    public class InternalServerErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is SqlException)
            {
               var sqlException = (SqlException)context.Exception;
               //Do your logging...
            }
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
