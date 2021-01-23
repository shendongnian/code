    // invoke update callback
    try {
        CacheEntryUpdateArguments args = new CacheEntryUpdateArguments(cache, reason, entry.Key, null);
        entry.CacheEntryUpdateCallback(args);
        Object expensiveObject = (args.UpdatedCacheItem != null) ? args.UpdatedCacheItem.Value : null;
        CacheItemPolicy policy = args.UpdatedCacheItemPolicy;
        // Dev10 861163 - Only update the "expensive" object if the user returns a new object,
        // a policy with update callback, and the change monitors haven't changed.  (Inserting
        // with change monitors that have already changed will cause recursion.)
        if (expensiveObject != null && IsPolicyValid(policy)) {
              cache.Set(entry.Key, expensiveObject, policy);
        }
        else {
              cache.Remove(entry.Key);
        }
