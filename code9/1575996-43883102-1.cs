    private int FindEntry(TKey key)
    {
        if (key == null)
        {
            ThrowHelper.ThrowArgumentNullException(ExceptionArgument.key);
        }
    
        if (buckets != null)
        {
            int hashCode = comparer.GetHashCode(key) & 0x7FFFFFFF;
            for (int i = buckets[hashCode % buckets.Length]; i >= 0; i = entries[i].next)
            {
                if (entries[i].hashCode == hashCode && comparer.Equals(entries[i].key, key)) return i;
            }
        }
        return -1;
    }
