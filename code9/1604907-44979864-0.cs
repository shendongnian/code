    //On Read
    CIPRecipe FindRecipe_ByUniqueID(string uniqueID)
    {
        var lockObj = _locks[LOCK_RECIPES];
        lockObj.EnterReadLock();
        try
        {
            foreach (var r in _recipes.Keys)
            {
                if (_recipes[r].UniqueID == uniqueID)
                {
                    return _recipes[r];
                }
            }
        }
        finally
        {
            lockObj.ExitReadLock();
        }
        return null;
    }
    //On write
    var lockObject = _locks[LOCK_RECIPES]; //Note this now uses the same lock object as the other method.
    lockObj.EnterWriteLock();
    try
    {
        foreach (var r in _recipes)
        {
            r.Value.UpdateSummary();
            summaries.Add((RecipeSummary)r.Value.Summary);
        }
    }
    finally
    {
        lockObj.ExitWriteLock();
    }
