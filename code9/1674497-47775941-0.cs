	public static IList<BtnCountViews> GetDefaultList()
	{
		var defaultList = Enumerable.Range(1, 365).Select(e =>
			new BtnCountViews
			{
				DayOfYear = e,
				BtnCount = 0,
				Views = 0
			}
		).ToList();
		
		return defaultList;
	}
