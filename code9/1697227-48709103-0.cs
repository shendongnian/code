        new SortField 
        {
            Field = Infer<YourType>(t => t.DispatchTimeInDays),
            Order = Nest.SortOrder.Ascending
        }
    };
    var searchRequest = new SearchRequest(typeof(YourType))
    {
        Sort = sort
        // other query details omitted
    };
    _client.Search<YourType>(searchRequest);
