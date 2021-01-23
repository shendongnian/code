    Dictionary<string, MapAttribute> properties = typeof(Question).GetProperties().ToDictionary(
        property => property.GetCustomAttribute<MapAttribute>().Field,
        property =>
        {
            var attribute = property.GetCustomAttribute<MapAttribute>();
            attribute.Property = property;
            return attribute;
        });
