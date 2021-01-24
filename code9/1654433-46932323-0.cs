    public class IsSuperUserHandler : IAuthorizationHandler
    {
        public virtual async Task HandleAsync(AuthorizationHandlerContext context)
        {
            foreach (var req in context.Requirements)
            {
                if (req is IsSuperUserRequirement || req is IsCustomerUserRequirement)
                {
                    if (context.User.IsInRole("super_user"))
                        context.Succeed(req);
                }
            }
        }
    }
