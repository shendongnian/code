    private static List<ActionSchedule> GetCurrentGroup(List<List<ActionSchedule>> actionLists, TimeSpan now)
	{
		var currentGroup = actionLists.SingleOrDefault(actionList => IsActive(actionList, now));
		if (currentGroup == null)
		{
			// Comparing each list with the next to see where 'now' fits for the 'next active group'
			// We assume lists are already ordered by their start time, and that their start/close times
			// don't overlap
			for (int i = 0; i < actionLists.Count; i++)
			{
				// index of the next list; if it's out of bounds, we reset to the first list, index 0
				int j = i + 1;
				if (j >= actionLists.Count)
					j = 0;
				var nextList = actionLists[j];
				var closeFirst = actionLists[i].Single(action => action.Mode == TaskJob.Close).Start;
				var loginLast = nextList.Single(action => action.Mode == TaskJob.Login).Start;
					
				if (TimeBetween(now, closeFirst, loginLast))
				{
					currentGroup = nextList;
					break;
				}
			}
		}
		return currentGroup;
	}
	private static bool IsActive(List<ActionSchedule> actionList, TimeSpan now)
	{
		var login = actionList.Single(action => action.Mode == TaskJob.Login).Start;
		var close = actionList.Single(action => action.Mode == TaskJob.Close).Start;
		return TimeBetween(now, login, close);
	}
	private static bool TimeBetween(TimeSpan now, TimeSpan start, TimeSpan end)
	{
		if (start < end)
			return start <= now && now <= end;
		return !(end < now && now < start);
	}
