    public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (action == null) throw new ArgumentNullException(nameof(action));
        return Iterator();
        IEnumerable<T> Iterator() // C# 7 Local Function
        {
           foreach(var item in source)
           {
               action(item);
               yield return item;
           }
        }
    }
