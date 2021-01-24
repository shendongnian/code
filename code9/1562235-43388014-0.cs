    public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
    {
        if (indexB > -1 && indexB < list.Count)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        return list;
    }
