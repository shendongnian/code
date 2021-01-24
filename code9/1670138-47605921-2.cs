    public T TryGetFirstOrDefault(Func<T, bool> predicate)
    {
        _lock.EnterReadLock();
        try
        {
            return _hashSet.FirstOrDefault(x=>predicate(x));
        }
        finally
        {
            if (_lock.IsReadLockHeld) _lock.ExitReadLock();
        }
    }
