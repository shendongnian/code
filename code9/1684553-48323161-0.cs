    public class WebApiResponseFilter : ActionFilterAttribute
    {
        private ILogUtils logUtils;
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            if (logUtils == null)
            {
                logUtils = StructureMapConfig.Container.GetInstance<ILogUtils>();
            }
            var httpContext = HttpContext.Current;
            var actionDescriptor = actionExecutedContext.ActionContext.ActionDescriptor;
            var requestId = httpContext.Request.Headers.GetValues("X-RequestId").First();
            var userId = httpContext.User.Identity.GetUserId();
            var userName = httpContext.User.Identity.GetUserName();
            var responseContent = actionExecutedContext.Response.Content;
            if (responseContent == null)
            {
                logUtils.LogUsage($"RESPONSE LOG ipAddress:{httpContext.Request.UserHostAddress} requestId:{requestId} userId:{userId} userName:{userName} action:{actionDescriptor.ControllerDescriptor.ControllerName}.{actionDescriptor.ActionName} response:n/a");
            }
            else
            {
                var response = Task.Run(async () => await responseContent.ReadAsStringAsync()).Result;
                response = AesManager.EncryptData(response);
                logUtils.LogUsage($"RESPONSE LOG ipAddress:{httpContext.Request.UserHostAddress} requestId:{requestId} userId:{userId} userName:{userName} action:{actionDescriptor.ControllerDescriptor.ControllerName}.{actionDescriptor.ActionName} response:{response}");
            }
        }
    }
