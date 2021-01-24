    // Approach #3
    string currentDate = DateTime.UtcNow.ToString("O");
    var parameters = new SearchParameters()
    {
        Filter = "soldDate lt " + currentDate,
        QueryType = QueryType.Full,
        Top = 5
    }
    
    results = indexClient.Documents.Search<Hotel>("title:john", parameters);
