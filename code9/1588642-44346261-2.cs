    // object instances
    A sourceInstance = new A();
    A_History destInstance = new A_History();
    MapSourceValuesToDestination(sourceInstance, destInstance);
    private void MapSourceValuesToDestination(object sourceObject, object destinationObject)
    {
        //get all properties
        PropertyInfo[] sourceProperties = typeof (sourceObject).GetProperties();
        PropertyInfo[] destinationProperties = typeof (destinationObject).GetProperties();
    
        // foreach in source
        foreach (PropertyInfo property in sourceProperties)
        {
            if (property != null)
            {
                string propertyName = property.Name;
                if (!string.IsNullOrEmpty(propertyName))
                {
                    // get destination property matched by name
                    PropertyInfo matchingProperty = destinationProperties.FirstOrDefault(x => x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));    
                    if (matchingProperty != null)
                    {
                        // get source value
                        object sourceValue = property.GetValue(sourceInstance);
                        if (sourceValue != null)
                        {
                            // set source value to destination
                            matchingProperty.SetValue(destInstance, sourceValue);
                        }
                    }
                }
            }
        }
    }
