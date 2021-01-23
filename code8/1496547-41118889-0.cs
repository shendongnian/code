    /// <summary>
    /// Gets a list of our documents
    /// </summary>
    /// <returns></returns>
    public List<T> List(string query)
    {
        // Return our items
        return
            this
              ._client
              .CreateDocumentQuery<T>(
                   UriFactory.CreateDocumentCollectionUri(this._databaseName, this._collectionName), 
                   query,
                   new FeedOptions { EnableCrossPartitionQuery = false };
              ).ToList();
    }
