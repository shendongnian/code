    using (var reader = File.OpenText(@""))
    using (var csv = new CsvReader(reader))
    using (var tbl = new DataTable())
    {
        while (csv.Read())
        {
            var row = tbl.NewRow();
            foreach(DataColumn col in tbl.Columns)
                row[col.ColumnName] = csv.GetField(col.DataType, col.ColumnName);
    
            tbl.Rows.Add(row);
        }
    
        using (var bcp = new SqlBulkCopy("my_conn", SqlBulkCopyOptions.UseInternalTransaction))
        {
            bcp.WriteToServer(tbl);
        }
    }
