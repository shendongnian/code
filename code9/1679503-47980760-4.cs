    public static TDestination MapProperty<TSource, TDestination>(TSource source, TDestination destination)
    {
        PropertyInfo[] sourceProperties = typeof(source).GetProperties();
        foreach(var property in sourceProperties)
        {
            var destinationProperty = typeof(TDestination).GetProperty(property.Name);
            if(destinationProperty != null)
            {
                // Error handling, validation of type, a bunch of other checks should go here.
                var value = ((destinationProperty.PropertyType)property.GetValue(source, null));
                destinationProperty.SetValue(destination, value, null);
            }
        }
    
        return destination;
    }
