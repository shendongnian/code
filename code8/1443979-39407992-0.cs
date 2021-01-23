    this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
    var query = this.client.CreateDocumentQuery<asset>(
             ... your LiNQ or SQL query...
        .AsDocumentQuery();
    var result = await query.ExecuteNextAsync<string>();
    Console.WriteLine(result.ToList().FirstOrDefault());
