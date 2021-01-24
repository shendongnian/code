    public class LoggingActionFilter : Attribute, IActionFilter
    {
        private DateTime start;
        private bool skipLogging = false;
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = (ControllerActionDescriptor)context.ActionDescriptor;
            var attributes = descriptor.MethodInfo.CustomAttributes.ToList();
            if (attributes.Count > 0 && attributes.Any(a => a.AttributeType == typeof(SkipLoggingAttribute)))
            {
                skipLogging = true;
                return;
            }
            start = DateTime.Now;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (skipLogging)
            {
                return;
            }
            DateTime end = DateTime.Now;
            double processTime = end.Subtract(start).TotalMilliseconds;
        }
    }
    public class SkipLoggingAttribute : Attribute
    {
    }
