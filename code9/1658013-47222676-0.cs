    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
            {
                case "PageAuthCheck":
                    return AuthorizeContactDetails(context);
                default:
                    return Nok();
            }
        }
    
        private Task<bool> AuthorizeContactDetails(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    return Eval(context.Principal.Identity.IsAuthenticated);
                case "Write":
                    return Eval(context.Principal.HasClaim("role", "Admin"));
                default:
                    return Nok();
            }
        }
    }
