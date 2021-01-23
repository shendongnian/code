    public void Create<T>(T[] items)
    {
    // table headers are created before this line.......
    var table = new DataTable();
    var props = typeof(T).GetProperties();
    foreach(var p in props)
        table.Columns.Add(p.Name, p.ReturnType);
    foreach(var o in items)
        foreach(var p in props)
           table.Rows.Add(p.GetValue(o));
    }
