    public static void UpdateWatchListsSort(string userId, List<WatchList> watchListsWithModifiedPosition)
    {
    	// Get the original ordered sequence
    	var oldSeq = GetWatchListsFromDb(userId);
    	// Create sequence with elements to be modified (ordered by the new position)
    	var modifiedSeq = watchListsWithModifiedPosition.OrderBy(e => e.Position);
    	// Extract ordered sequence with the remaining elements (ordered by the original position) 
    	var otherSeq = oldSeq.Except(watchListsWithModifiedPosition);
    	// Build the new ordered sequence by merging the two 
    	var newSeq = new List<WatchList>(oldSeq.Count);
    	using (var modifiedIt = modifiedSeq.GetEnumerator())
    	using (var otherIt = otherSeq.GetEnumerator())
    	{
    		var modified = modifiedIt.MoveNext() ? modifiedIt.Current : null;
    		var other = otherIt.MoveNext() ? otherIt.Current : null;
    		while (modified != null || other != null)
    		{
    			if (modified != null && modified.Position == newSeq.Count + 1)
    			{
    				newSeq.Add(modified);
    				modified = modifiedIt.MoveNext() ? modifiedIt.Current : null;
    			}
    			else
    			{
    				newSeq.Add(other);
    				other = otherIt.MoveNext() ? otherIt.Current : null;
    			}
    		}
    	}
    	// Here the new sequence elements are in the correct order
    	// Update the Position field and populate a list 
    	// with the items that need db update
    	var updateList = new List<WatchList>();
    	for (int i = 0; i < newSeq.Count; i++)
    	{
    		var item = newSeq[i];
    		if (item.Id == oldSeq[i].Id) continue;
    		item.Position = i + 1;
    		updateList.Add(item);
    	}
    }
