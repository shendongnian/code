    public class WebAPiExceptionHandler : IExceptionHandler
    {
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var fout = new ErrorInformation
            {
                Message = "Iets is misgegaan"
                , ErrorDate = DateTime.UtcNow
            };
            var httpResponse = context.Request.CreateResponse(HttpStatusCode.InternalServerError, fout);
            context.Result = new ResponseMessageResult(httpResponse);
            return Task.FromResult(0);
        }
        private class ErrorInformation
        {
            public string Message { get; set; }
            public DateTime ErrorDate { get; set; }
        }
    }
