    public static async Task<T> GetItemAsync(string id, string deviceId)
    {
        try
        {
            RequestOptions options = new RequestOptions();
            options.PartitionKey = new PartitionKey(deviceId);
            Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), options);
            return (T)(dynamic)document;
        }
        catch (DocumentClientException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw;
            }
        }
    }
