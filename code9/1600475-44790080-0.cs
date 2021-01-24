    public void Setup(DocumentClient client)
    {
        await client.CreateDatabaseIfNotExistsAsync(new Database() { Id = databaseId });
        await client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(databaseId), new DocumentCollection { Id = "Identity" });
    }
