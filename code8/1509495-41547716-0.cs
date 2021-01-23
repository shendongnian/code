    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class UnAuthenticatedOnlyAttribute : ActionFilterAttribute
    {
        public string RedirectTo { get; set; } = "/Error";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
                filterContext.Result = new RedirectResult(RedirectTo);
        }
    }
