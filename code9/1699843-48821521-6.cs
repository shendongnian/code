 	Dictionary<string,IEnumerable<Rate>> groupedSet = new Dictionary<string, IEnumerable<Rate>>();
	
	foreach (var key in currencyCode)
	{
		IEnumerable<Rate> _result = rate.Where(x => x.CurrencyCode.Contains(key));
		if (_result.Any())
		{
			groupedSet.Add(key, _result);			
		}
	}
