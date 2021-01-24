    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(string claim, string failUrl) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { claim, failUrl };
        }
    }
    public class ClaimRequirementFilter : IAsyncActionFilter
    {
        private readonly string _claim;
        private readonly string _failUrl;
        public ClaimRequirementFilter(string claim, string failUrl)
        {
            _claim = claim;
            _failUrl = failUrl;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.User.Claims.Any(c => c.Value == _claim))
            {
                context.Result = new RedirectResult(_failUrl);
            }
            else
            {
                await next();
            }
        }
    }
