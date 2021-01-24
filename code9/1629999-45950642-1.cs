    // todo: turn into async filter.
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;
        private readonly IHostingEnvironment _env;
        public ApiExceptionFilterAttribute(ILogger<ApiExceptionFilterAttribute> logger, IHostingEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(new EventId(0), context.Exception, context.Exception.Message);
            dynamic errObject = new JObject();
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError; // use 500 unless the API says it's a client error
            if (context.Exception.GetType() == typeof(CustomApiException))
            {
                CustomApiException customEx = (CustomApiException)context.Exception;
                if (customEx.ApplicationErrorCode != null) errObject.errorCode = customEx.ApplicationErrorCode;
                errObject.errorMessage = customEx.Message;
                statusCode = customEx.HttpStatusCode;
            }
            if (_env.IsDevelopment())
            {
                errObject.errorMessage = context.Exception.Message;
                errObject.type = context.Exception.GetType().ToString();
                errObject.stackTrace = context.Exception.StackTrace;
            }
            JsonResult result = new JsonResult(errObject);
            result.StatusCode = (int?)statusCode;
            context.Result = result;
        }
    }
