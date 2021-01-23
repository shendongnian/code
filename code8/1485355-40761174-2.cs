    public class RequireProjectAccessAttribute : TypeFilterAttribute
    {
        public string RouteKey { get; set; }
        public RequireProjectAccessAttribute(string routeKey) : base(typeof(RequireProjectAccessFilter))
        {
            RouteKey = routeKey;
            Arguments = new object[] { routeKey };
        }
        private class RequireProjectAccessFilter : IAsyncActionFilter
        {
            private readonly ICurrentSession _currentSession;
            private readonly string _routeKey;
            public RequireProjectAccessFilter(ICurrentSession currentSession, string routeKey)
            {
                _currentSession = currentSession;
                _routeKey = routeKey;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var projectId = context.HttpContext.GetRouteValue(_routeKey)?.ToString();
                if (/* user doesn't have access to project */)
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    await next();
                }
            }
        }
    }
