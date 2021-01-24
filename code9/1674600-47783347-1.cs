    private void Insert(TKey key, TValue value, bool add) {    
    // Snip 
        int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
        int targetBucket = hashCode % buckets.Length;
    // Snip 
        for (int i = buckets[targetBucket]; i >= 0; i = entries[i].next) {
            if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) {
    // Key found.  Set the new value at the old location in the entries array.
                if (add) { 
                    ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_AddingDuplicate);
                }
                entries[i].value = value;
                version++;
                return;
            }  
            // Snip 
        }
    // Key not found, add to the dictionary.
        int index;
        if (freeCount > 0) {
    // Free entries exist because items were previously removed; recycle the position in the entries array.
            index = freeList;
            freeList = entries[index].next;
            freeCount--;
        }
        else {
    // No free entries.  Add to the end of the entries array, resizing if needed.
            if (count == entries.Length)
            {
                Resize();
                targetBucket = hashCode % buckets.Length;
            }
            index = count;
            count++;
        }
 
    // Set the key and value in entries array.
        entries[index].hashCode = hashCode;
        entries[index].next = buckets[targetBucket];
        entries[index].key = key;
        entries[index].value = value;
        buckets[targetBucket] = index;
    // Snip remainder
