    var newClient = new Client
    {
        ClientName = client.ClientName,
        ClientId = client.ClientId,
        ClientSecrets = secrets.ToList() // or ToArray or whatever it is
    };
    _dbContext.Clients.Add(newClient);
    await _dbContext.SaveChangesAsync();
