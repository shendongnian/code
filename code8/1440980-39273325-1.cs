    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class AuthorizeHubAttribute : AuthorizeAttribute
    {
        public override bool AuthorizeHubConnection (HubDescriptor hubDescriptor, IRequest request)
        {
            var token = request.QueryString["Authorization"];
            var ticket = Startup.OAuthOpt.AccessTokenFormat.Unprotect(token);
            if ( ticket != null && ticket.Identity != null && ticket.Identity.IsAuthenticated )
            {
                request.Environment["server.User"] = new ClaimsPrincipal(ticket.Identity);
                return true;
            }
            else
                return false;
        }
        public override bool AuthorizeHubMethodInvocation (IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            var connectionId = hubIncomingInvokerContext.Hub.Context.ConnectionId;
            var environment = hubIncomingInvokerContext.Hub.Context.Request.Environment;
            var principal = environment["server.User"] as ClaimsPrincipal;
            if ( principal != null && principal.Identity != null && principal.Identity.IsAuthenticated )
            {
                hubIncomingInvokerContext.Hub.Context = new HubCallerContext(new Microsoft.AspNet.SignalR.Owin.ServerRequest(environment), connectionId);
                return true;
            }
            else
                return false;
        }
    }
