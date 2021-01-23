    var lines = System.IO.File.ReadAllLines(@"d:\data.txt");
    if (lines.Count() == 0) return;
    var columns = lines[0].Split(',');
    var table = new DataTable();
    foreach (var c in columns)
        table.Columns.Add(c);
    for (int i = 1; i < lines.Count() - 1; i++)
        table.Rows.Add(lines[i].Split(','));
    var connection = @"your connection string";
    var sqlBulk = new SqlBulkCopy(connection);
    sqlBulk.DestinationTableName = "Table1";
    sqlBulk.WriteToServer(table);
