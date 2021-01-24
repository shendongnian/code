    private static readonly TimeSpan GapSize = TimeSpan.FromSeconds(3);
    public static IEnumerable<IEnumerable<TimeSpan>> GetGroups(IEnumerable<TimeSpan> timespans)
    {
    	var timespansList = timespans.ToList();
    	while (timespansList.Count > 0)
    	{
    		TimeSpan min = timespansList.Min();
    		var closeList = timespansList.Where(t => t - min <= GapSize).ToList();
    		yield return closeList;
    		foreach (var timeSpan in closeList)
    		{
    			timespansList.Remove(timeSpan);
    		}
    	}
    }
