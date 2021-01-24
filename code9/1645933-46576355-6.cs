    public static DataTable ConverToDataTable(IEnumerable<object> obj)
    {
        DataTable dt = new DataTable();
    
        var dataType = obj.First().GetType();
    
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
    
        foreach (var item in obj)
        {
            DataRow newRow = dt.NewRow();
            foreach (var prop in dataType.GetProperties())
            {
                newRow[prop.Name] = prop.GetValue(item);
            }
            dt.Rows.Add(newRow);
        }
    
        return dt;
    }
