    IEnumerable<IPEndPoint> endpoints;
    if (RoleEnvironment.IsEmulated)
    {
        endpoints = Dns.GetHostEntry(Dns.GetHostName())
            .AddressList
            .Select(address => new IPEndPoint(address, 9100));
    }
    else
    {
        endpoints = RoleEnvironment.CurrentRoleInstance
            .InstanceEndpoints
            .Select(endpoint => endpoint.Value.IPEndpoint);
    }
            
