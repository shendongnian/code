    public static IEnumerable<T> Pipe<T>(this IEnumerable<T> source, Action<T> action)
    {    
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (action == null) throw new ArgumentNullException(nameof(action));
        return _(); IEnumerable <T> _()
        {
            foreach (var element in source)
            {
                action(element);
                yield return element;
            }
        }
    }
