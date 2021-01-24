    IDocumentQuery<MyDocument> query = client.CreateDocumentQuery<MyDocument>(UriFactory.CreateDocumentCollectionUri(_database, _collection),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true, MaxDegreeOfParallelism = 199, MaxBufferedItemCount = 100000})
                .Where(predicate)
                .AsDocumentQuery();
          while (query.HasMoreResults)
            {
                FeedResponse<MyDocument> feedResponse = await query.ExecuteNextAsync<MyDocument>();
                Console.WriteLine (feedResponse.Select(x => x.data.Select(y => y.avg)));
            }
