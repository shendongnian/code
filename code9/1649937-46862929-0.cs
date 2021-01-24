    public class FacebookRequirement : AuthorizationHandler<FacebookRequirement>, IAuthorizationRequirement
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, FacebookRequirement requirement)
            {
                var socialConfig = new SocialConfig { Facebook = new SocialApp { AppId = "<FacebookAppId>", AppSecret = "<FacebookAppSecret>" } };
                var socialservice = new SocialAuthService(socialConfig);
    
                var authorizationFilterContext = context.Resource as AuthorizationFilterContext;
                if (authorizationFilterContext == null)
                {
                    context.Fail();
                    return Task.FromResult(0);
                }
    
                var httpContext = authorizationFilterContext.HttpContext;
                if (httpContext != null && httpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    var authorizationHeaders = httpContext.Request.Headers.Where(x => x.Key == "Authorization").ToList();
                    var token = authorizationHeaders.FirstOrDefault(header => header.Key == "Authorization").Value.ToString().Split(' ')[1];
    
                    var user = socialservice.VerifyTokenAsync(new ExternalToken { Provider = "Facebook", Token = token }).Result;
                    if (!user.IsVerified)
                    {
                        context.Fail();
                        return Task.FromResult(0);
                    }
    
                    context.Succeed(requirement);
                    return Task.FromResult(0);
                }
    
                context.Fail();
                return Task.FromResult(0);
            }
        }
