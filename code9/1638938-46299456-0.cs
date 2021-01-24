    public class ActiveUserFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            var userName = context.HttpContext.User.Identity.IsAuthenticated
            ? context.HttpContext.User.GetClaim("email")
            : "(unknown)";
            using (LogContext.PushProperty("ActiveUser", !string.IsNullOrWhiteSpace(userName) ? userName : "(unknown)"))
                await next();
        }
    }
