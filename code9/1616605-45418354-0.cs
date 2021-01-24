    foreach (var item in items)
    {
        Console.WriteLine("{0}", item.id);
        foreach (var val in item.values)
        {
            Console.WriteLine("{0}", val.fieldName);
        }
    }
