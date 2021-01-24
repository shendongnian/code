    public static IList<T> ToList<T>(this System.Data.DataTable table, Dictionary<string, string> mappings)
        where T : new()
    {
        IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
        return table.Rows.OfType<DataRow>().Select(row => CreateItemFromRow<T>(row, properties, mappings))
                  .ToList();        
    }
