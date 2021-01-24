    // Choose the property name and value keys.
    var propertyKey = "Block";
    var valuesKey = "HouseNo";
    // Generate the Dictionary<string, string []>
    var dictionary = dataTable.AsEnumerable()
        // Generate a lookup table of all houses for each block
        .ToLookup(r => r.Field<string>(propertyKey), r => r.Field<string>(valuesKey))
        // And convert to a dictionary of names and array values for JSON serialization.
        .ToDictionary(g => propertyKey + " " + g.Key, g => g.ToArray());
    // Now serialize to JSON with your preferred serializer.  Mine is Json.NET
    var json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
