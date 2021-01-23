    public static void ShowList<T>(this IEnumerable<T> Values)
    {
        if (Values is String)
            Console.WriteLine(Values);
        else
            foreach (T item in Values)
            {
                Console.WriteLine(item);
            }
    }
