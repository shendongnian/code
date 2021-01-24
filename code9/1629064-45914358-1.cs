    static IEnumerable<IEnumerable<T>> AllPermutations<T>(IEnumerable<T>list, int maxLength)
    {
        IEnumerable<IEnumerable<T>> newList = null;
        for (int i = 1; i <= maxLength; i++)
        { if (newList == null) { newList = PermutationOfObjects(list, i); } else newList = newList.Union(PermutationOfObjects(list, i)); }
        return newList;
    }
