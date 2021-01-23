    public void Create<T>(T[] items)
    {
    
        var table = new DataTable();
        var props = typeof(T).GetProperties();
        // Dynamically create headers
        foreach(var p in props)
        {
            if(!table.Columns.Contains(p.Name))
               table.Columns.Add(p.Name, p.ReturnType);
        }
        // Dynamically add values
        foreach(var o in items)
        {
            var row = table.NewRow();
            foreach(var p in props)
            {
               row[p.Name] = p.GetValue(o);
            }
            table.Rows.Add(row);
        }
    }
