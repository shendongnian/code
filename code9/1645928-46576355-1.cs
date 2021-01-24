    public static DataTable ConverToDataTable(object obj)
    {
        DataTable dt = new DataTable();
    
        var dataType = obj.GetType();
    
        dataType.GetProperties().ToList().ForEach(f =>
        {
            try
            {
                dt.Columns.Add(f.Name, f.PropertyType);
            }
            catch
            {
    
            }
        });
    
        DataRow newRow = dt.NewRow();
        foreach (var prop in dataType.GetProperties())
        {
            newRow[prop.Name] = prop.GetValue(obj);
        }
        dt.Rows.Add(newRow);
    
        return dt;
    }
