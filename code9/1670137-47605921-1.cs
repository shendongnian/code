    public T TryGetFirstOrDefault()
    {
        _lock.EnterReadLock();
        try
        {
            return _hashSet.FirstOrDefault();
        }
        finally
        {
            if (_lock.IsReadLockHeld) _lock.ExitReadLock();
        }
    }
