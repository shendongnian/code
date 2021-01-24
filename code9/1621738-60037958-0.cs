    var props = new AuthenticationProperties(new Dictionary<string, string>
    {
        {
            "client_id", clientId
        },
    });
    
    var ticket = new AuthenticationTicket(identity, props);
    context.Validated(ticket);    
