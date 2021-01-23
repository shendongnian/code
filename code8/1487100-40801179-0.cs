    foreach (Car car in carColl)
    {
        foreach (string propName in propertyNames)
        {
              Console.WriteLine(typeof(Car).GetProperty(propName).GetValue(ent).ToString());
        }
    }
