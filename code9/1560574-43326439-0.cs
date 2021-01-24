    foreach (DictionaryEntry entry in dictionary)
    {
        string valueAsString = ((Geometry)entry.Value).ToString(CultureInfo.InvariantCulture);
        var Data = Geometry.Parse(valueAsString);
        ...
