    object[] parameters = new object[]
    {
        propertyToRead.GetValue(objectToRead),
        propertyToSet.GetValue(objectToSet)
    };
    typeof(MapperObject).GetMethod("Convert")
        .MakeGenericMethod(new Type[]
            {
                propertyToRead.PropertyType,
                propertyToSet.PropertyType
            })
        .Invoke(mapperInstance, parameters);
    propertyToSet.SetValue(objectToSet, parameters[1]);
