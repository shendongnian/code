    foreach (var data in list)
    {
        try
        {
            data.Property.Setter(instance, Convert.ChangeType(dbDataReader[data.Name], data.Property.Type));
        }
        catch(ArgumentException e)
        {
            data.Property.Setter(null, Convert.ChangeType(dbDataReader[data.Name], data.Property.Type));
        }
    }
