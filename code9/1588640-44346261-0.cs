    // object instances
    A sourceInstance = new A();
    A_History destInstance = new A_History();
    
    //get all properties
    PropertyInfo[] sourceProperties = typeof (A).GetProperties();
    PropertyInfo[] destinationProperties = typeof (A_History).GetProperties();
    
    // foreach in source
    foreach (PropertyInfo property in sourceProperties)
    {
    if (property != null)
                    {
                        string propertyName = property.Name;
    
                        if (!string.IsNullOrEmpty(propertyName))
                        {
                            // get destination property matched by name
                            PropertyInfo matchingProperty = destinationProperties.FirstOrDefault(
                                x => x.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));
    
                            if (matchingProperty != null)
                            {
                                // get source value
                                object sourceValue = property.GetValue(sourceInstance);
                                // set source value to destination
                                matchingProperty.SetValue(destInstance, sourceValue);
                            }
                        }
                    }
                }
