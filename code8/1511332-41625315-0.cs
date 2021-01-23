	var client = new ElasticClient();
    // just change .Index() for .AllIndices() for indices
	var mappings = client.GetMapping<object>(m => m.Index("posts").AllTypes());
    foreach (var index in mappings.IndexTypeMappings)
    {
        foreach (var type in index.Value)
        {
            // do something with type names
            Console.WriteLine($"index: '{index.Key.Name}', type: '{type.Key.Name}'");
        }
    }
