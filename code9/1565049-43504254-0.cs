    // Approach #1
    string currentDate = DateTime.UtcNow.ToString("O");
    var parameters = new SearchParameters()
    {
        Filter = "soldDate lt " + currentDate,
        Top = 5
    }
    
    results = indexClient.Documents.Search<Hotel>("john", parameters);
