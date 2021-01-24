    ///<summary>Finds the index of the first item matching an expression in an enumerable</summary>
    ///<param name="items">The enumerable to search</param>
    ///<param name="predicate">The expression to test the items against</param>
    ///<returns>The index of the first matching item, or -1 if no items match</returns>
    public static int IndexOf<T>([NotNull] this IEnumerable<T> items, [NotNull] Func<T, bool> predicate)
    {
        int index = 0;
        foreach (T item in items)
        {
            if (predicate(item)) return index;
            index++;
        }
        return -1;
    }
