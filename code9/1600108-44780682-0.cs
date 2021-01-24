    var tagsToMatch = new List<Tag>()
    {
        new Tag("Type", "One"),
        new Tag("Category", "A")
    };
    
    var singleTagToMatch = tagsToMatch.First();
    
    var query = client
        .CreateDocumentQuery<T>(documentCollectionUri)
        .Where(d => d.Tags.Contains(singleTagToMatch));
