    public class AuthorizePermissionAttribute : TypeFilterAttribute
    {
        public AuthorizePermissionAttribute(params Permission[] permissions)
            : base(typeof(PermissionFilter))
        {
            Arguments = new[] { new PermissionRequirement(permissions) };
            Order = Int32.MinValue;
        }
    }    
    
    public class PermissionFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authService;
        private readonly PermissionRequirement _requirement;
        public PermissionFilter(IAuthorizationService authService, PermissionRequirement requirement)
        {
            _authService = authService;
            _requirement = requirement;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            bool ok = await _authService.AuthorizeAsync(context.HttpContext.User, null, _requirement);
            if (!ok) context.Result = new ChallengeResult();
        }
    } 
