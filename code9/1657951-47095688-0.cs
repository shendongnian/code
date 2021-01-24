    class MyExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            if (context.Request.Method == HttpMethod.Get && context.Request.RequestUri.AbsolutePath == "/odata/projects")
            {
                if (IsDivideByZero(context.Exception))
                {
                    const string message = "Division by zero encountered while applying the filter";
                    var response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError(message));
                    context.Result = new ResponseMessageResult(response);
                }
            }
            return Task.CompletedTask;
        }
        private static bool IsDivideByZero(Exception ex)
        {
            if (ex is SqlException sqlEx && sqlEx.Number == 8134)
                return true;
            return ex.InnerException != null && IsDivideByZero(ex.InnerException);
        }
    }
