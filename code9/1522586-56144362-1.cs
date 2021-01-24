    public class ThePolicyAuthorizationHandler : AuthorizationHandler<ThePolicyRequirement>
        {
            readonly AppDbContext _context;
            readonly IHttpContextAccessor _contextAccessor;
    
            public ThePolicyAuthorizationHandler(DbContext c, IHttpContextAccessor ca)
            {
                _context = c;
                _contextAccessor = ca;
            }
    
            protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ThePolicyRequirement requirement)
            {
                if (context.Resource is AuthorizationFilterContext filterContext)
                {
                    var area = (filterContext.RouteData.Values["area"] as string)?.ToLower();
                    var controller = (filterContext.RouteData.Values["controller"] as string)?.ToLower();
                    var action = (filterContext.RouteData.Values["action"] as string)?.ToLower();
                    var id = (filterContext.RouteData.Values["id"] as string)?.ToLower();
                    if (await requirement.Pass(_context, _contextAccessor, area, controller, action, id))
                        context.Succeed(requirement);
                    else
                        context.Fail();
    
                }
                else if (context.Resource is PolicyResource policyResource)
                {
                    var pr = policyResource;
                    if (await requirement.Pass(_context, _contextAccessor, pr.Area, pr.Controller, pr.Action, pr.Id))
                        context.Succeed(requirement);
                    else
                        context.Fail();
                }
                else
                {
                    context.Fail();
                }
            }
        }
