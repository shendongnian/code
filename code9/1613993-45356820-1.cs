    Expression<Func<Client, ClientDTO>> clientProjection = client => new ClientDTO
    {
        ID = client.ClientID,
        FirstName = client.FirstName,
        // ...
        Products = client.Products.Select(productProjection.Compile()).ToList(),
        // ...
    };
