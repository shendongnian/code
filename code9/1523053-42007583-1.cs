	public IEnumerable<string> GetValidObjects(JObject obj, IEnumerable<string> values)
	{
		return obj["objects"]
			.Where(i => (string)i["state"]["type"] == values.First() && ContainsState((JArray)i["state"]["childs"], values.Skip(1)))
			.Select(i => (string)i["name"]);
	}
	
	public bool ContainsState(JArray childs, IEnumerable<string> values)
	{
		if (childs == null)
		{
			return values.Count() == 0;
		}
		
		return childs.Any(i => (string)i["state"]["type"] == values.First() && ContainsState((JArray)i["state"]["childs"], values.Skip(1)));
	}
