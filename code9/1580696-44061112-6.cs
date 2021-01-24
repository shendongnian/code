	var searcher = searcherManager.Acquire();
	try
	{
		var topDocs = searcher.Search(query, 10);
		_totalHits = topDocs.TotalHits;
		foreach (var result in topDocs.ScoreDocs)
		{
			var doc = searcher.Doc(result.Doc);
			l.Add(new SearchResult
			{
				Name = doc.GetField("name")?.GetStringValue(),
				Description = doc.GetField("description")?.GetStringValue(),
				Url = doc.GetField("url")?.GetStringValue(),
				// Results are automatically sorted by relevance
				Score = result.Score,
			});
		}
	}
	catch (Exception e)
	{
		Console.WriteLine(e.ToString());
	}
	finally
	{
		searcherManager.Release(searcher);
		searcher = null; // Never use searcher after this point!
	}
