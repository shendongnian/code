    public class CustomSqlException : Exception
    {
        public SqlCommand ExecutedCommand { get; }
    
        public CustomException(SqlCommand executedCommand) 
            : base("Custom Message")
        {
            ExecutedCommand = executedCommand;
        }
    }
    public class InternalServerErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is CustomSqlException)
            {
                var sqlException = (CustomSqlException)context.Exception;
                var command = sqlException.ExecutedCommand;
                //Do your logging...
            }
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
