    static string GetContentProperty<TSource>()
    {
        return typeof(TSource).GetTypeInfo().CustomAttributes
            .Where(a => a.AttributeType == typeof(ContentPropertyAttribute))
            .FirstOrDefault()?.NamedArguments.Cast<CustomAttributeNamedArgument?>()
            .Where(n => n.Value.MemberName == "Name")
            .FirstOrDefault()?.TypedValue.Value.ToString();
    }
