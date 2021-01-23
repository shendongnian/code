    private bool HasNull(object webServiceInput, string[] optionalParameters = null)
    {
        if (ReferenceEquals(null, webServiceInput))
            return false;
        if (optionalParameters == null)
            optionalParameters = new string[0];
        var binding = BindingFlags.Instance | BindingFlags.Public;
        var properties = webServiceInput.GetType().GetProperties(binding);
        foreach (var property in properties)
        {
            if (!property.CanRead)
                continue;
            if (property.PropertyType.IsValueType)
                continue;
            if (optionalParameters.Contains(property.Name))
                continue;
            var value = property.GetValue(webServiceInput);
            if (ReferenceEquals(null, value))
                return false;
        }
        return true;
    }
