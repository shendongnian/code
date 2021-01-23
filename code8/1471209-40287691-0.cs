    public static void UpdateWatchListsSort(string userId, List<WatchList> watchListsWithModifiedPosition)
    {
    	// Get the existing items and sort them by Position
    	var itemList = GetWatchListsFromDb(userId);
    	itemList.Sort((a, b) => a.Position.CompareTo(b.Position));
    	// Apply the modifications to the list
    	var updateMap = watchListsWithModifiedPosition.ToDictionary(e => e.Id);
    	for (int index = 0; index < itemList.Count; index++)
    	{
    		var item = itemList[index];
    		// Should update?
    		WatchList updateInfo;
    		if (!updateMap.TryGetValue(item.Id, out updateInfo)) continue;
    		int newIndex = updateInfo.Position - 1;
    		if (newIndex == index) continue;
    		// Move the item to the correct position
    		itemList.RemoveAt(index);
    		itemList.Insert(newIndex, item);
    		// Mark it as processed
    		updateMap.Remove(item.Id);
    	}
    	// Here the list elements are in the correct order
    	// Update the Position field and populate a list 
    	// with the items that need db update
    	var updateList = new List<WatchList>();
    	for (int index = 0; index < itemList.Count; index++)
    	{
    		var item = itemList[index];
    		int newPosition = index + 1;
    		if (item.Position == newPosition) continue;
    		item.Position = newPosition;
    		updateList.Add(item);
    	}
    }
