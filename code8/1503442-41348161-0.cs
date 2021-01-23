    public class FailedApiRequestLoggerAttribute : ActionFilterAttribute
    {
        private readonly bool _removeErrorDetailsFromResponse;
        public FailedApiRequestLoggerAttribute(bool removeErrorDetailsFromResponse)
        { _removeErrorDetailsFromResponse = removeErrorDetailsFromResponse; }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var log = LoggerFactory.GetLogger(actionExecutedContext.ActionContext.ControllerContext.Controller.GetType().Name);
            // If there is no response object then we're probably here because an exception was 
            // thrown and thrown exceptions are handled elsewhere.
            if (actionExecutedContext.Response?.IsSuccessStatusCode == false)
            {
                var error = new StringBuilder();
                error.AppendLine("API Call Returned Non-Success Status");
                error.AppendLine($"{actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName}.{actionExecutedContext.ActionContext.ActionDescriptor.ActionName}");
                if (actionExecutedContext.ActionContext.ActionArguments.Any())
                { error.AppendLine($"  Arguments"); }
                foreach (var argument in actionExecutedContext.ActionContext.ActionArguments)
                { error.AppendLine($"    {JsonConvert.SerializeObject(argument)}"); }
                error.AppendLine("  Response");
                error.AppendLine($"    Status Code: {actionExecutedContext.Response.StatusCode}; Reason: {actionExecutedContext.Response.ReasonPhrase}");
                var content = actionExecutedContext.Response.Content as ObjectContent<HttpError>;
                if (content != null)
                {
                    error.AppendLine($"    {JsonConvert.SerializeObject(content.Value)}");
                    if (_removeErrorDetailsFromResponse)
                    { ((HttpError)content.Value).Clear(); }
                }
                log.Warning(error.ToString());
            }
        }
    }
