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
                // add this list to the other storage (a HashSet that removes duplicates)
                foreach (T item in list)
                    itemStorage.Add(item);
            }
            else
            {
                itemStorage = new HashSet<T>(list, comparer);
                // each items needs to be added to the dictionary, all have the same storage
                foreach (T item in itemStorage)
                    itemListDict.Add(item, itemStorage); // same storage for all
            }
        }
        // Distinct removes duplicate HashSets because of reference equality
        //  needed because item was the key and it's storage the value
        //  and those HashSets are the same reference
        return itemListDict.Values.Distinct();  
    }
