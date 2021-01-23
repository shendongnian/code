	public IEnumerable<KeyValuePair<string, int>> GetWordFrequency(List<string> words)
	{
		return words.GroupBy(w => w)
					.Select((item) => new KeyValuePair<string, int>(item.Key, item.Count()));
	}
