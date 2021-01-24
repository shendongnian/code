    var rows = File.ReadAllText(path).Split('|')
        .Select((field, index) => new { field, index })
        .GroupBy(x => x.index / 12)
        .Select(g => g.Select(x => x.field).ToArray());
    
    DataTable table = new DataTable();
    for(int i = 0; i < 12; i++)
        table.Columns.Add();
    foreach(var row in rows)
        table.Rows.Add(row);
