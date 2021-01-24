    if (fi.FieldType.IsGenericType && fi.FieldType.GetGenericTypeDefinition() == typeof(List<>))
    {
        var value = (IList)fi.GetValue(myObject); // <- get field value, cast it to IList
        foreach (var element in value)
        {
            Console.WriteLine(element);
        }
    }
