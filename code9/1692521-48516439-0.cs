    string EndpointUrl = "https://xxxx.documents.azure.com:443/";
    string PrimaryKey = "{your_key}";
    DocumentClient client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);
    
    FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1 };
    
    DateTime dtn = new DateTime(2018, 1, 25);
                
    IQueryable<Document> DocQueryInSql = client.CreateDocumentQuery<Document>(
            UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
            "SELECT * FROM c WHERE udf.ToDate(c._ts) > '"+ dtn.ToString("yyyy-MM-dd") + "'",
            queryOptions);
    
    string pattern = @"(:conversation)|(:private)";
    System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex(pattern);
    
    foreach (Document doc in DocQueryInSql)
    {
        if (rgx.Matches(doc.Id).Count>0)
        {
            //Console.WriteLine("\tRead {0}", doc.Id);
    
            await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri("{your_db_name}", "{your_collection_name", doc.Id));
        }
    }
