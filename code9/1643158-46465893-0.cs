    public static string Join(this IEnumerable list)
    {
        if (!(list is IEnumerable<object> objects))
            objects = list.Cast<object>();
        return string.Join(", ", objects);
    }
