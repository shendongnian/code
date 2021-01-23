    var properties = TypeDescriptor.GetProperties(typeof(Car));
    foreach (Car car in carColl)
    {
        foreach (string propName in propertyNames)
        {
            Console.WriteLine(properties[propName].GetValue(car));
        }
    }
