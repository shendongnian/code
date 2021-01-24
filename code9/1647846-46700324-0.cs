    for (int i = 0; i < allObjects.Count; i++)
    {
        //new property to record the index in the array
        allObjects[i].Index = i;
    }
    var allCombinations = new int[allObjects.Count, allObjects.Count];
    foreach (var thisObj in allObjects)
    {
        foreach (var otherObj in allObjects)
        {
            allCombinations[thisObj.Index, otherObj.Index] = (thisObj.Id == otherObj.Id ? 0 : 100);
        }
    }
