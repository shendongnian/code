    private static void ReplaceValues<TSource>(IEnumerable<TSource> source, object oldValue,
        object newValue)
    {
        var properties = typeof(TSource).GetProperties();
        foreach (var item in source)
        {
            foreach (var propertyInfo in properties.Where(t => Equals(t.GetValue(item), oldValue)))
            {
                propertyInfo.SetValue(item, newValue);
            }
        }
    }
