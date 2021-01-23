    var query = new
    {
        query = new
        {
            match = new
            {
                _all = new
                {
                    query = "bkala"
                }
            }
        }
    };
    var searchResult = client.LowLevel.Search<SearchResponse<MyDocument>>(query);
    
