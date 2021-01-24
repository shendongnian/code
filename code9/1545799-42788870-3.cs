            private void Insert(TKey key, TValue value, bool add) {
            
                if( key == null ) {
                    ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
                }
     
                if (buckets == null) Initialize(0);
                int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
                int targetBucket = hashCode % buckets.Length;
     
    #if FEATURE_RANDOMIZED_STRING_HASHING
                int collisionCount = 0;
    #endif
     
                for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next) {
                    if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) {
                        if (add) { 
                            ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
                        }
                        entries[i].value = value;
                        version++;
                        return;
                    } 
     
    #if FEATURE_RANDOMIZED_STRING_HASHING
                    collisionCount++;
    #endif
                }
                int index;
                if (freeCount > 0) {
                    index = freeList;
                    freeList = entries[index].next;
                    freeCount--;
                }
                else {
                    if (count == entries.Length)
                    {
                        Resize();
                        targetBucket = hashCode % buckets.Length;
                    }
                    index = count;
                    count++;
                }
     
                entries[index].hashCode = hashCode;
                entries[index].next = buckets[targetBucket];
                entries[index].key = key;
                entries[index].value = value;
                buckets[targetBucket] = index;
                version++;
     
    #if FEATURE_RANDOMIZED_STRING_HASHING
     
    #if FEATURE_CORECLR
                // In case we hit the collision threshold we'll need to switch to the comparer which is using randomized string hashing
                // in this case will be EqualityComparer<string>.Default.
                // Note, randomized string hashing is turned on by default on coreclr so EqualityComparer<string>.Default will 
                // be using randomized string hashing
     
                if (collisionCount > HashHelpers.HashCollisionThreshold && comparer == NonRandomizedStringEqualityComparer.Default) 
                {
                    comparer = (IEqualityComparer<TKey>) EqualityComparer<string>.Default;
                    Resize(entries.Length, true);
                }
    #else
                if(collisionCount > HashHelpers.HashCollisionThreshold && HashHelpers.IsWellKnownEqualityComparer(comparer)) 
                {
                    comparer = (IEqualityComparer<TKey>) HashHelpers.GetRandomizedEqualityComparer(comparer);
                    Resize(entries.Length, true);
                }
    #endif // FEATURE_CORECLR
     
    #endif
     
            }
