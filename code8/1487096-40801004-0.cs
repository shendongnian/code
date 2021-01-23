    var properties = TypeDescriptor.GetProperties(typeof(Car));
    foreach (Car car in carColl)
    {
        foreach (string propName in propertyNames)
        {
            // It is what I want to do. But car.propName don't work
            Console.WriteLine(properties[propName].GetValue(car));
        }
    }
