	public static void UpdateWatchListsSort(string userId, List<WatchList> watchListsWithModifiedPosition)
	{
		var modifiedIds = new HashSet<int>(watchListsWithModifiedPosition.Select( w=>w.Id ));
		List<WatchList> allUserWatchLists = GetWatchListsFromDb(userId);
		var modifiedWatchLists = allUserWatchLists.FindAll(w => modifiedIds.Contains(w.Id)).ToDictionary(w => w.Id);
			
		var newList = new List<WatchList>();
		var unmodifiedIter = allUserWatchLists.FindAll(w => !modifiedIds.Contains(w.Id)).GetEnumerator();
		foreach (WatchList modified in watchListsWithModifiedPosition.OrderBy(w => w.Position))
		{
			int newIndex = modified.Position - 1;
			while(newList.Count < newIndex && unmodifiedIter.MoveNext())
				newList.Add(unmodifiedIter.Current);
			newList.Add(modifiedWatchLists[modified.Id]);
		}
		while(unmodifiedIter.MoveNext())
			newList.Add(unmodifiedIter.Current);
		allUserWatchLists = newList;
 
        //... Your testing and Position fix-up code ...
    }
