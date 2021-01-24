    var collectionEntry = context.Entry(objectToDetach).Collection(propertyInfo.Name);
    if (collectionEntry.IsLoaded)
    {
    	var collection = collectionEntry.CurrentValue;
    	if (collection != null)
    	{
    		collectionsToRestore.Add(Tuple.Create(collectionEntry, collection));
    		collectionEntry.CurrentValue = null;
    		foreach (var item in (IEnumerable)collection)
    		{
    			if (!visitedObjects.Contains(item))
    			{
    				DetachRec(item, visitedObjects, collectionsToRestore);
    			}
    		}
    	}
    }
