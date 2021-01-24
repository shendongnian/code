    var clientModel = new Client
    {
        ClientId = "",
        ClientName = "",
        // ...
    };
    _configurationDbContext.Clients.Add(clientModel.ToEntity());
    await _configurationDbContext.SaveChangesAsync();
