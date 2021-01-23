    IDocumentQuery<Document> query = client.CreateDocumentChangeFeedQuery(
        collectionUri,
        new ChangeFeedOptions
        {
            PartitionKeyRangeId = pkRange.Id,
            StartFromBeginning = true,
            RequestContinuation = continuation,  // From last call to change feed
            MaxItemCount = -1
        });
    // Paginate through all results currently available
    while (query.HasMoreResults)
    {
        FeedResponse<DeviceReading> readChangesResponse = query.ExecuteNextAsync<DeviceReading>().Result;
        foreach (DeviceReading changedDocument in readChangesResponse)
        {
            Console.WriteLine("\tRead document {0} from the change feed.", changedDocument.Id);
            numChangesRead++;
        }
        // Save token for resuming after some time
        checkpoints[pkRange.Id] = readChangesResponse.ResponseContinuation;
    }
