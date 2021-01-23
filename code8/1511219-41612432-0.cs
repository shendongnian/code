    ISolrOperations<Product> solr = ...
    var products = solr.Query(SolrQuery.All, new QueryOptions {
        ExtraParams = new Dictionary<string, string> {
            {"collection", "collection1,collection2,collection3"}
        }
    });
