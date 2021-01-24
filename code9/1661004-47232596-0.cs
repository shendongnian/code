	public static List<Data> GetResults(List<Data> list1, List<Data> list2)
	{
		var joined = list1.FullJoin(list2, key1 => key1.Abbrv,
			firstSelector => new Data
			{
				Abbrv = firstSelector.Abbrv,
				Date = firstSelector.Date,
				Desc = firstSelector.Desc
			},
			secondSelector => new Data
			{
				Abbrv = secondSelector.Abbrv,
				Date = secondSelector.Date,
				Desc = secondSelector.Desc
			},
			(first, second) => new Data
			{
				Abbrv = second.Abbrv,
				Date = second.Date,
				Desc = second.Desc
			});
		var mem = joined.ToList();
		return mem;
	}
