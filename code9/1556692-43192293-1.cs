    private bool IsPropertyDefinied(JSchema schema, string propertyName)
    {
        if (schema._properties != null && schema._properties.ContainsKey(propertyName))
        {
            return true;
        }
    ...
