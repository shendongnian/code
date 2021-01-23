	private IList<IDictionary<string, string>> BuildDictionary<T>(HashSet<T> someHashSetOfTs) where T : ICommon
	{
		IList<IDictionary<string, string>> data = new List<IDictionary<string, string>>();
		foreach (var a in someHashSetOfTs)
		{
			Dictionary<string, string> aDictionary = new Dictionary<string, string>();
			aDictionary.Add(a.Code, a.Code + "," + a.Name);
			data.Add(aDictionary);
		}
		return data;
	}
