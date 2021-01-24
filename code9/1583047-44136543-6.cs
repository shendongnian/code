    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> elements, Action<T, int> action) 
    { 
        int count = 0; 
        foreach (var item in elements) 
        {
            action(item, count++); 
            yield return item; 
        }
    }
