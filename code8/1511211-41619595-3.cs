    var getAttributeValueMethod = typeof(Microsoft.Xrm.Sdk.Entity).GetMethod("GetAttributeValue");
    foreach (var property in typeof (PersonAddress).GetProperties())
    {
        var generic = getAttributeValueMethod.MakeGenericMethod(property.PropertyType);
        var attributeValue = generic.Invoke(entity,
                                            new object[] {
                                            property.Name.ToLowerInvariant()});
    }
