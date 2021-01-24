    public static void Dump<T>(this IEnumerable<T> source)
    {
        foreach(var item in source)
           Console.WriteLine(item);
    }
