    public static IEnumerable<T> BeforeLastNonMatch<T>(this IEnumerable<T> seq, Func<T, bool> predicate)
    {
        IList<T> listOrArray = seq as IList<T>;
        if (listOrArray == null)
            listOrArray = seq.ToList();
        int indexOfLastmatch = -1;
        for (int i = listOrArray.Count - 1; i >= 0; i--)
        {
            bool match = predicate(listOrArray[i]);
            if (match)
                indexOfLastmatch = i;
            else
                break;
        }
        if (indexOfLastmatch >= 0)
        {
           for (int i = 0; i < indexOfLastmatch - 1; i++)
            {
                yield return listOrArray[i];
            }
        }
    }
