    public static IEnumerable<T> RemoveConsecutiveDuplicates<T>(this IEnumerable<T> collection)
    {
        using (var enumerator = collection.GetEnumerator())
        {
            bool wasNotLast = enumerator.MoveNext(), 
                 hasEntry = wasNotLast;
            T last = hasEntry ? enumerator.Current : default(T);
            
            while(wasNotLast)
            {
                if (!last.Equals(enumerator.Current))
                    yield return last;
                last = enumerator.Current;
                wasNotLast = enumerator.MoveNext();
            }
            if (hasEntry)
                yield return last;
        }
    }
