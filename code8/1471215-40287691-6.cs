    public static void UpdateWatchListsSortB(string userId, List<WatchList> modifiedList)
    {
    	var originalList = GetWatchListsFromDb(userId);
    	var updateList = modifiedList
    		.Concat(Enumerable.Range(1, originalList.Count).Except(modifiedList.Select(e => e.Position))
    		.Zip(originalList.Except(modifiedList), (pos, e) => e.Position == pos ? e : new WatchList(e.Id) { Position = pos }))
    		.Where(e => e.Id != originalList[e.Position - 1].Id)
    		.ToList();
    }
