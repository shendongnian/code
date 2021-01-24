            /// <summary>
            /// Shared internal implementation for inserts and updates.
            /// If key exists, we always return false; and if updateIfExists == true we force update with value;
            /// If key doesn't exist, we always add value and return true;
            /// </summary>
            [SuppressMessage("Microsoft.Concurrency", "CA8001", Justification = "Reviewed for thread safety")]
            private bool TryAddInternal(TKey key, TValue value, bool updateIfExists, bool acquireLock, out TValue resultingValue)
            {
                while (true)
                {
                    int bucketNo, lockNo;
                    int hashcode;
     
                    Tables tables = m_tables;
                    IEqualityComparer<TKey> comparer = tables.m_comparer;
                    hashcode = comparer.GetHashCode(key);
                    GetBucketAndLockNo(hashcode, out bucketNo, out lockNo, tables.m_buckets.Length, tables.m_locks.Length);
     
                    bool resizeDesired = false;
                    bool lockTaken = false;
    #if FEATURE_RANDOMIZED_STRING_HASHING
    #if !FEATURE_CORECLR                
                    bool resizeDueToCollisions = false;
    #endif // !FEATURE_CORECLR
    #endif
     
                    try
                    {
                        if (acquireLock)
                            Monitor.Enter(tables.m_locks[lockNo], ref lockTaken);
     
                        // If the table just got resized, we may not be holding the right lock, and must retry.
                        // This should be a rare occurence.
                        if (tables != m_tables)
                        {
                            continue;
                        }
     
    #if FEATURE_RANDOMIZED_STRING_HASHING
    #if !FEATURE_CORECLR
                        int collisionCount = 0;
    #endif // !FEATURE_CORECLR
    #endif
     
                        // Try to find this key in the bucket
                        Node prev = null;
                        for (Node node = tables.m_buckets[bucketNo]; node != null; node = node.m_next)
                        {
                            Assert((prev == null && node == tables.m_buckets[bucketNo]) || prev.m_next == node);
                            if (comparer.Equals(node.m_key, key))
                            {
                                // The key was found in the dictionary. If updates are allowed, update the value for that key.
                                // We need to create a new node for the update, in order to support TValue types that cannot
                                // be written atomically, since lock-free reads may be happening concurrently.
                                if (updateIfExists)
                                {
                                    if (s_isValueWriteAtomic)
                                    {
                                        node.m_value = value;
                                    }
                                    else
                                    {
                                        Node newNode = new Node(node.m_key, value, hashcode, node.m_next);
                                        if (prev == null)
                                        {
                                            tables.m_buckets[bucketNo] = newNode;
                                        }
                                        else
                                        {
                                            prev.m_next = newNode;
                                        }
                                    }
                                    resultingValue = value;
                                }
                                else
                                {
                                    resultingValue = node.m_value;
                                }
                                return false;
                            }
                            prev = node;
     
    #if FEATURE_RANDOMIZED_STRING_HASHING
    #if !FEATURE_CORECLR
                            collisionCount++;
    #endif // !FEATURE_CORECLR
    #endif
                        }
     
    #if FEATURE_RANDOMIZED_STRING_HASHING
    #if !FEATURE_CORECLR
                        if(collisionCount > HashHelpers.HashCollisionThreshold && HashHelpers.IsWellKnownEqualityComparer(comparer)) 
                        {
                            resizeDesired = true;
                            resizeDueToCollisions = true;
                        }
    #endif // !FEATURE_CORECLR
    #endif
     
                        // The key was not found in the bucket. Insert the key-value pair.
                        Volatile.Write<Node>(ref tables.m_buckets[bucketNo], new Node(key, value, hashcode, tables.m_buckets[bucketNo]));
                        checked
                        {
                            tables.m_countPerLock[lockNo]++;
                        }
     
                        //
                        // If the number of elements guarded by this lock has exceeded the budget, resize the bucket table.
                        // It is also possible that GrowTable will increase the budget but won't resize the bucket table.
                        // That happens if the bucket table is found to be poorly utilized due to a bad hash function.
                        //
                        if (tables.m_countPerLock[lockNo] > m_budget)
                        {
                            resizeDesired = true;
                        }
                    }
                    finally
                    {
                        if (lockTaken)
                            Monitor.Exit(tables.m_locks[lockNo]);
                    }
     
                    //
                    // The fact that we got here means that we just performed an insertion. If necessary, we will grow the table.
                    //
                    // Concurrency notes:
                    // - Notice that we are not holding any locks at when calling GrowTable. This is necessary to prevent deadlocks.
                    // - As a result, it is possible that GrowTable will be called unnecessarily. But, GrowTable will obtain lock 0
                    //   and then verify that the table we passed to it as the argument is still the current table.
                    //
                    if (resizeDesired)
                    {
    #if FEATURE_RANDOMIZED_STRING_HASHING
    #if !FEATURE_CORECLR
                        if (resizeDueToCollisions)
                        {
                            GrowTable(tables, (IEqualityComparer<TKey>)HashHelpers.GetRandomizedEqualityComparer(comparer), true, m_keyRehashCount);
                        }
                        else
    #endif // !FEATURE_CORECLR
                        {
                            GrowTable(tables, tables.m_comparer, false, m_keyRehashCount);
                        }
    #else
                        GrowTable(tables, tables.m_comparer, false, m_keyRehashCount);
    #endif
                    }
     
                    resultingValue = value;
                    return true;
                }
            }
