    public class ReplaceHeaderPolicy : IAuthorizationRequirement
    {
    }
    public class ReplaceHeaderHandler : AuthorizationHandler<ReplaceHeaderPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ReplaceHeaderPolicy requirement)
        {
            if (!context.User.Identity.IsAuthenticated)
            { 
                var fc = (FilterContext)context.Resource;
                fc.HttpContext.Response.Headers["X-HelloWorld"] = string.Empty;
            }
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
