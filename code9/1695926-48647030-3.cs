    public class AuthorizeViewFilter : System.Web.Http.Filters.IAuthorizationFilter
    {
        private readonly IAccessRightsService _iAccessRightService;
        public AuthorizeViewFilter(IAccessRightsService iAccessRightService)
        {
            _iAccessRightService = iAccessRightService;
        }
    
        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            RoleFeature roleFeature = _iAccessRightService.GetRoleFeatures();
    
            if (roleFeature.IsView)
            {
                return continuation();
            }
            else
              return Task.FromResult(actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Access denied"));
        }
    }
