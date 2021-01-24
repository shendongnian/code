    var clientModel = new Client
    {
        ClientId = "",
        ClientName = "",
        // ...
    };
    await _configurationDbContext.SaveChangesAsync(clientModel.ToEntity());
