    private DataDate table = null;
    
    public void ConverToDataTable(object obj)
    {
        var dataType = obj.GetType();
        
        if (table == null)
        {
            table = new DataTable();
    
            dataType.GetProperties().ToList().ForEach(f =>
            {
                    table.Columns.Add(f.Name, f.PropertyType);
            });
        }
    
        DataRow newRow = table.NewRow();
        foreach (var prop in dataType.GetProperties())
        {
            newRow[prop.Name] = prop.GetValue(obj);
        }
        table.Rows.Add(newRow);
    }
