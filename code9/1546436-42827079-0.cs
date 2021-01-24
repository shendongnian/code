    var nameQuery = db.Clients
        .Where(x => x.Name.Contains(searchString))
        .Select(x => new SearchResultItem {
            ResultLabel = client.Name,
            SearchResultType = SearchResultType.ClientName,
        });
