    var ds = new DataSet();
    ds.Tables.Add(new DataTable()); // 0
    ds.Tables.Add(new DataTable()); // 1
    ds.Tables.Add(new DataTable()); // 2
    ds.Tables.Add(new DataTable()); // 3
    for (int i = 1; i < ds.Tables.Count; i++)
    {
        var currentTable = ds.Tables[i];
        if (currentTable == null)
        {
            Response.Write("Table is null!");
        }
    }
