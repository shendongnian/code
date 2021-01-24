    try
       {
         RequestOptions options = new RequestOptions();
         options.PartitionKey = new PartitionKey("jay");
         options.ConsistencyLevel = ConsistencyLevel.Session;
         return await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, SecurityCollectionId, id), item,options).ConfigureAwait(false);
       }
         catch (Exception ex)
       {
         Logger.Log(ErrorLevel.Error, ex.Message);
         throw ex;
       }
