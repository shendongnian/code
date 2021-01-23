    public static void UpdateWatchListsSort(string userId, List<WatchList> watchListsWithModifiedPosition)
    {
		var modifiedIds = new HashSet<int>(watchListsWithModifiedPosition.Select( w=>w.Id ));
        List<WatchList> allUserWatchLists = GetWatchListsFromDb(userId);
		var modifiedWatchLists = allUserWatchLists.FindAll(w => modifiedIds.Contains(w.Id)).ToDictionary(w => w.Id);
		
		allUserWatchLists.RemoveAll( w => modifiedIds.Contains(w.Id));
		foreach (WatchList modified in watchListsWithModifiedPosition.OrderBy(w => w.Position))
		{
			int newIndex = modified.Position - 1;
			allUserWatchLists.Insert(newIndex, modifiedWatchLists[modified.Id]);
		}
 
        //... Your testing code ...
    }
