    public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, 
        IRequest request)
    {
        //This should be sent in the Header - but will not work with
        //Websockets, if a custom header is required, ensure the transport type is "LongPolling" for demo purposes, QueryString was chosen. 
        var token = request.QueryString.Get("Token");
        if (string.IsNullOrWhiteSpace(token))
            return false;
            //Logic omitted to perform checks and the validity of a request
            if (client == null)
                return false;
            //build the claims identity
            Claim clientIdClaim = new Claim("Id", "SignalR: " + client.Id.ToString());
            Claim clientNameClaim = new Claim(ClaimTypes.Name, "SignalR: " + client.ClientName);
            List<Claim> claims = new List<Claim>
            {
                clientIdClaim,
                clientNameClaim,
            };
            //"Basic" is required to ensure IsAuthenticated is set, amongst others.
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");
            // set the authenticated user principal into environment so that it can be used in the future
            request.Environment["server.User"] = new ClaimsPrincipal(identity);
            return true;
      }
      public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
      {
        var connectionId = hubIncomingInvokerContext.Hub.Context.ConnectionId;
        // check the authenticated user principal from environment
        var environment = hubIncomingInvokerContext.Hub.Context.Request.Environment;
        var principal = environment["server.User"] as ClaimsPrincipal;
        if (principal == null || 
            principal.Identity == null || 
            principal.Identity.IsAuthenticated == false)
            return false;
        
            // create a new HubCallerContext instance with the principal generated from token
            // and replace the current context so that in hubs we can retrieve current user identity
            hubIncomingInvokerContext.Hub.Context = new HubCallerContext(new ServerRequest(environment), connectionId);
            return true;
    }
