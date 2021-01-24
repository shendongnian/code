    IEnumerable<MyObject> records = GetRecords();
    IEnumerable<PropertyInfo> readableProperties= typeof(MyObject).GetProperties
        .Where(property => property.CanRead);
    var propertyValues = readableProperties   // for every property
        .Select(propertyInfo => new           // create one new object of anonymous type
    {                                                     
        PropertyName = propertyInfo.Name,     // with the name of the property
        PropertyValues = records              // and a sequence of all values of this property
            .Select(record => propertyInfo.GetValue(record))
    }
