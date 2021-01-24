    public class ActivityLogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (actionDescriptor != null)
            {
                var attribute = actionDescriptor.MethodInfo.GetCustomAttribute<MyLogAttribute>();
                if (attribute != null)
                {
                    context.HttpContext.Items["MyLogData"] = GetRelevantLogData(context.ActionArguments); // Apply some custom logic to select relevant log data
                }
            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                if (actionDescriptor != null)
                {
                    var attribute = actionDescriptor.MethodInfo.GetCustomAttribute<MyLogAttribute>();
                    if (attribute != null)
                    {
                        var actionParametersData = (MyActionParametersLogData)context.HttpContext.Items["MyLogData"]
    
                        LoggerHelper.Log(actionParametersData, context.Result);
                    }
                }
            }
        }
    }
