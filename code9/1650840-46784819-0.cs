    public static AppendWordEveryCount<T>(this IEnumerable<T> source, T itemToAppend, int count)
    {
        int counter = 0;                    // a counter to find every count element
        foreach (T item in source)
        {
            yield return T;                 // just return the item in your sequence
            counter = (counter + 1) % count;
            if (i == 0)                     // after count elements
            {
                 yield return wordToAppend; // append the item
            }
        }
    }
