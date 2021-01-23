     // Query asychronously.
    using (var client = new DocumentClient(new Uri(endpointUrl), authorizationKey, _connectionPolicy))
    {
         var propertiesOfUser =
            client.CreateDocumentQuery<Property>(_collectionLink)
                .Where(p => p.OwnerId == userGuid)
                .AsDocumentQuery(); // Replaced with ToList()
    while (propertiesOfUser.HasMoreResults) 
    {
        foreach(Property p in await propertiesOfUser.ExecuteNextAsync<Property>())
         {
             // Iterate through Property to have List or any other operations
         }
    }
        
    }
