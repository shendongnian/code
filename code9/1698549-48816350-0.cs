	var client = new ElasticClient();
    // number of slices in slice scroll
    var numberOfSlices = 4;
	var scrollObserver = client.ScrollAll<MyObject>("1m", numberOfSlices, s => s
		.MaxDegreeOfParallelism(numberOfSlices)
		.Search(search => search
			.Index("test")
			.Type("one")
			.Term(t => t.name, "A")
		)
	).Wait(TimeSpan.FromMinutes(60), r =>
	{
        // do something with documents from a given response.
        var documents = r.SearchResponse.Documents;
	});
