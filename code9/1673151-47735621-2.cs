	string key = String.Join(",", new[] { country, type })
	bool success = processor.TryGetValue(key, out Handler handler);
	if (success)
	{
		handler.Execute();
	}
	else
	{
		throw new Exception("unknown country");
	}
