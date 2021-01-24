    mustClauses.Add(new TermQuery
    {
        Field = new Field("description"),
        Value = "white"
    });
    filterClauses.Add(new NumericRangeQuery
    {
        Field = new Field("price"),
        LessThanOrEqualTo = 3000,
        GreaterThanOrEqualTo = 2000
    });
    var searchRequest = new SearchRequest<Product>(indexName)
    {
        Size = 10,
        From = 0,
        Query = new BoolQuery 
        { 
            Must = mustClauses,
            Filter = filterClauses
        }
    };
    var searchResponse = client.Search<Product>(searchRequest);
