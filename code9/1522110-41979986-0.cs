    DataTable table = new DataTable();
    table.Columns.AddRange(new DataColumn[]
        {
            new DataColumn(),
            new DataColumn(),
            new DataColumn()
        });
    
    table.Rows.Add(1, 2, 3);
        
    foreach (DataRow dr in table.Rows)
    {
        dr[0] = 99;
    }
