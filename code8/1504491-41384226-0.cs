    public static IEnumerable<T> ReplaceAt<T>(this IEnumerable<T> collection, int index, T item)
    {
        var currentIndex = 0;
        foreach (var originalItem in collection)
        {
            if (currentIndex != index)
            {
                //keep the original item in place
                yield return originalItem;
            }
            else
            {
                //we reached the index where we want to replace
                yield return item;
            }
            currentIndex++;
        }
    }
