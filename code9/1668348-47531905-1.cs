    public static List<SelectListItem> ToSelectItemList<T>(this IEnumerable<T> collection, Func<T, string> nameGetter, Func<T, int> idGetter)
    {
        return collection.Select(m => new SelectListItem
        {
            Text = nameGetter(m),
            Value = idGetter(m).ToString()
        }).ToList();
    }
