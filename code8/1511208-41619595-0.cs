    var getAttributeValueMethod = typeof(Entity).GetMethod("GetAttributeValue");
    foreach (var property in typeof (Contact).GetProperties())
    {
        var generic = getAttributeValueMethod.MakeGenericMethod(property.PropertyType);
        dynamic attributeValue = generic.Invoke(entity, new object[] {property.Name.ToLowerInvariant()});
    }
