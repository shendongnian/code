	public void Process(string data)
	{
		var assignments = new Dictionary<string, Action<Question, string>>()
		{
			{ "0", (q, t) => q.Id = t },
			{ "1", (q, t) => q.Name = t },
			// ...
			{ "99",  (q, t) => q._99 = t },
		};
	
		Question question = new Question();
		string[] fields = data.Split(':');
	
		for (int i = 0; i < fields.Length; i += 2)
		{
			assignments[fields[i]](question, fields[i + 1]);
		}
	}
