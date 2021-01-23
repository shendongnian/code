    var clients = Uow.Clients.AsNoTracking().where(x => x.zipCode= newZip);
    var newClients = new List<Client>();
    foreach (var client in clients)
    {
        client.City = null;
        client.cityId = newCityId;
        newClients.Add(client);
    }
    
    Uow.Clients.AddMany(client);
    Uow.Commit();
