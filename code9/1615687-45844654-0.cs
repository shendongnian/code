    public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
            {
                
                if (context.User.HasClaim(c => c.Type == "role" && c.Value =
     requirement.Permission))
                {
                    System.Console.WriteLine("User  has required permission: " + requirement.Permission);
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
                System.Console.WriteLine("User is forbidden");
                return Task.CompletedTask;
            }
        }
