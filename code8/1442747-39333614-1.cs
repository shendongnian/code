    public static IEnumerable<T> LastN<T>(this IList<T> list, int n)
    {
        if (list == null) 
        {
            throw new ArgumentNullException("list");
        }
        if (list.Count - n < 0) 
        {
            n = list.Count;
        }
        for (var i = list.Count - n; i < list.Count; i++) 
        {
            yield return list[i];
        }
    }
    // use 
    var tail50 = myList.LastN(50); 
