    public class MyRequirementHandler : AuthorizationHandler<MyRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
    
        public MyRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
           _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
    
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MyRequirement requirement)
        {
            var routeData = _httpContextAccessor.HttpContext.GetRouteData();
    
            var areaName = routeData?.Values["area"]?.ToString();
            var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;
    
            var controllerName = routeData?.Values["controller"]?.ToString();
            var controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;
    
            var actionName = routeData?.Values["action"]?.ToString();
            var action = string.IsNullOrWhiteSpace(actionName) ? string.Empty : actionName;
    
            //...
        }
    }
