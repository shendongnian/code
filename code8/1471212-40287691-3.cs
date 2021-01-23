    public static void UpdateWatchListsSort(string userId, List<WatchList> watchListsWithModifiedPosition)
    {
    	// Get the original ordered sequence
    	var oldSeq = GetWatchListsFromDb(userId);
    	// Build the new ordered sequence
    	var newSeq = new WatchList[oldSeq.Count];
    	// Place the modified elements in their new position
    	foreach (var item in watchListsWithModifiedPosition)
    		newSeq[item.Position - 1] = item;
    	// Place the remaining elements in the free slots, keeping the original order
    	var remainingSeq = Enumerable.Range(0, newSeq.Length)
    		.Where(index => newSeq[index] == null)
    		.Zip(oldSeq.Except(watchListsWithModifiedPosition), (index, item) => new { index, item });
    	foreach (var entry in remainingSeq)
    		newSeq[entry.index] = entry.item;
    	// Update the Position field and populate a list with the items that need db update
    	var updateList = new List<WatchList>();
    	for (int i = 0; i < newSeq.Length; i++)
    	{
    		var item = newSeq[i];
    		if (item.Id == oldSeq[i].Id) continue;
    		item.Position = i + 1;
    		updateList.Add(item);
    	}
    }
