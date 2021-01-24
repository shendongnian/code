    public static T FindItemAfter<T>(this IList<T> list, T targetItem, T defaultValue)
    {
        var index = list.IndexOf(targetItem);
        if (index == -1 || index >= list.Count - 1)
        {
            return defaultValue;
        }
        return list[index + 1];
    }
