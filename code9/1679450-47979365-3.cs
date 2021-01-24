    public static bool TryAssignValue<T>(out T value,
                                         Func<T, bool> predicate,
                                         params T[] options)
    {
        var found = false;
        value = default(T);
        foreach (var o in options)
        {
            if (predicate(o))
            {
                if (found)
                {
                    return false;
                }
                else
                {
                    value = o;
                    found = true;
                }
            }
        }
        return found;
    }
