	client.Index(new PercolatedQuery
	{
		Id = "std_query",
		Query = new MatchQuery
		{
			Field = Infer.Field<LogEntryModel>(entry => entry.Message),
			Query = "just a text"
		}
	}, d => d.Index(logIndex).Refresh(Refresh.WaitFor));
