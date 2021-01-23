    private readonly ElasticClient _client; //needs to be initialized in your code
    public void Index(IEnumerable<Person> documents)
        {
            var bulkIndexer = new BulkDescriptor();
            foreach (var document in documents)
            {
                bulkIndexer.Index<Person>(i => i
                    .Document(document)
                    .Id(document.SearchDocumentId)
                    .Index(_indexName));
            }
            _client.Bulk(bulkIndexer);
        }
