    public IEnumerable<KeyValuePair<string, int>> GetFilteredCalls(
        Expression<Func<Call, bool>> predicate)
    {
    	return calls
    		.Where(predicate)
    		.GroupBy(c => c.LanguageCode)
    		.Select(g => new { Lang = g.Key, Count = g.Count() })
    		.ToDictionary(x => x.Lang, y => y.Count)
    		.OrderByDescending(x => x.Key);
    }
