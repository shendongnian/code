            string continuationToken = null;
            int pageSize = 500;
            do
            {
                var r = await client.ExecuteStoredProcedureAsync<dynamic>(
                    UriFactory.CreateStoredProcedureUri(DatabaseId, CollectionId, "SP_NAME"),
                    new RequestOptions { PartitionKey = new PartitionKey("...") },
                    continuationToken, pageSize);
                var documents = r.Response.result;
                // processing documents ...
                // 'dynamic' could be easily substituted with a class that will cater your needs
                continuationToken = r.Response.continuation;
            }
            while (!string.IsNullOrEmpty(continuationToken));       
