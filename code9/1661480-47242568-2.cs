    public object GetDefaultPropertyValue(Control c)
    {
        var defaultPropertyAttribute = c.GetType().GetCustomAttributes(true)
            .OfType<DefaultPropertyAttribute>().FirstOrDefault();
        var defaultProperty = defaultPropertyAttribute.Name;
        return c.GetType().GetProperty(defaultProperty).GetValue(c);
    }
