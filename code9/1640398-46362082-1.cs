    public static IEnumerable<IEnumerable<T>> MergeIntersectingLists<T>(this IEnumerable<IEnumerable<T>> itemLists, IEqualityComparer<T> comparer = null) 
    {
        if (comparer == null) comparer = EqualityComparer<T>.Default;
        var itemListDict = new Dictionary<T, HashSet<T>>(comparer);
        foreach (IEnumerable<T> sequence in itemLists)
        {
            IList<T> list = sequence as IList<T> ?? sequence.ToList();
            HashSet<T> itemStorage = null;
            list.FirstOrDefault(i => itemListDict.TryGetValue(i, out itemStorage));
            // FirstOrDefault will initialize the itemStorage because its an out-parameter
            bool partOfListIsContainedInOther = itemStorage != null;
            if (partOfListIsContainedInOther)
            {
                // add whole list to that "list"
                foreach (T item in list)
                    itemStorage.Add(item);
            }
            else
            {
                // each items needs to be added to the dictionary
                itemStorage = new HashSet<T>(list, comparer);
                foreach (T item in itemStorage)
                    itemListDict.Add(item, itemStorage); // same storage for all
            }
        }
        return itemListDict.Values.Distinct();  // Distinct removes duplicate HashSets because of reference equality
    }
