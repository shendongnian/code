    DataTable table = new DataTable();
    table.Columns.Add(new DataColumn { ColumnName = "ilosc", DataType = typeof(long) });
    table.Rows.Add(table.NewRow());
    table.Rows[0]["ilosc"] = 3;
    var test2 = new object[(long)table.Rows[0]["ilosc"]];
