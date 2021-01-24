    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public LogActionFilterAttribute(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Method == HttpMethods.Post || context.HttpContext.Request.Method == HttpMethods.Put)
            {
                // Check parameter those are marked for not to log.
                var methodInfo = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).MethodInfo;
                var noLogParameters = methodInfo.GetParameters().Where(p => p.GetCustomAttributes(true).Any(t => t.GetType() == typeof(NoLogAttribute))).Select(p => p.Name);
                StringBuilder logBuilder = new StringBuilder();
                
                foreach (var argument in context.ActionArguments.Where(a => !noLogParameters.Contains(a.Key)))
                {
                    var serializedModel = JsonConvert.SerializeObject(argument.Value, new JsonSerializerSettings() { ContractResolver = new NoPIILogContractResolver() });
                    logBuilder.AppendLine($"key: {argument.Key}; value : {serializedModel}");
                }
                var telemetry = this.httpContextAccessor.HttpContext.Items["Telemetry"] as Microsoft.ApplicationInsights.DataContracts.RequestTelemetry;
                if (telemetry != null)
                {
                    telemetry.Context.GlobalProperties.Add("jsonBody", logBuilder.ToString());
                }
            }
            await next();
        }
    }
