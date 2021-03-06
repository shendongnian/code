    private List<T> BuildToDelete(
        IList<T> newItems, 
        IList<T> existingItems, 
        Func<T, int> getId)
    {
        var missingItems = new List<T>();
    
        var items = newitems.Select(getId);
        var newItemIds = new HashSet<int>(items);
    
        foreach (var item in existingItems)
        {
            if (newItems.Count() == 0)
            {
                missingItems.Add(item);
            }
            else
            {
                if (!newItemsIds.Contains(getId(item)))
                {
                    missingItems.Add(item);
                }
            }
        }
    
        return missingItems;
    }
