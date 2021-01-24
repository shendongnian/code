    public class LogActionFilter : ActionFilterAttribute
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _logger.Trace("{0} Controller: {1}, Action: {2}",
                          MethodBase.GetCurrentMethod().Name,
                          filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                          filterContext.ActionDescriptor.ActionName);
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _logger.Trace("{0} Controller: {1}, Action: {2}",
                          MethodBase.GetCurrentMethod().Name,
                          filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                          filterContext.ActionDescriptor.ActionName));
            base.OnActionExecuted(filterContext);
        }
    }
