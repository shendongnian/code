    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    public class DomainHandler : AuthorizationHandler<DomainRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            DomainRequirement requirement)
        {
            var emailAddressClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.Email);
            if (emailAddressClaim != null && emailAddressClaim.Value.EndsWith($"@{requirement.Domain}"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
