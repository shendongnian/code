    public static bool TryAssignValue<T>(out T value,
                                         Func<T, bool> predicate,
                                         params T[] options)
    {
        var count = 0;
        value = default(T);
        foreach (var o in options)
        {
            if (predicate(o))
            {
                value = o;
                count += 1;
            }
        }
        if (count != 1)
        {
            value = default(T);
            return false;
        }
        return true;
    }
