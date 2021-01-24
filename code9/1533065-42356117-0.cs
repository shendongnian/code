    var aggregations = new AggregationDictionary();
    var aggKey = "some_name1";
    AggregationContainer nestedAgg = new NestedAggregation("some_name1")
    {
        Path = "users",
        Aggregations = new TermsAggregation("some_name2")
        {
            Field = "users.name.keyword",
            Size = 100,
            Order = new List<TermsOrder> 
            { 
                new TermsOrder() { Key = "_term", Order = Nest.SortOrder.Descending } 
            }
        }
    };
    
    aggregations[aggKey] = nestedAgg;
    var searchRequest = new SearchRequest<Test>();
    searchRequest.Aggregations = aggregations;
    
    client.Search<Test>(searchRequest);
