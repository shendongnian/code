    rwLock.EnterReadLock();
    try
    {
        // do stuff
    }
    finally
    {
        rwLock.ExitReadLock();
    }
