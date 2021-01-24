    DataTable a = new DataTable();
    a.ExtendedProperties.Add(1, "Hello");
    a.ExtendedProperties.Add(2, "World");
    var test = a.ExtendedProperties.Values;
    foreach (string b in test)
    {
        Console.WriteLine(b.ToString());
    }
