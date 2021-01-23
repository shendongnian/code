    var table = new DataTable();
    table.Columns.Add("double");
    table.Columns.Add("float");
    table.Columns.Add("decimal");
    dataGrid1.DataSource = table;
    table.Columns[0].DataType = typeof(double);
    table.Columns[1].DataType = typeof(float);
    table.Columns[2].DataType = typeof(decimal);
    table.Rows.Add(new object[] { 0.00000000000423, 0.00000000000423, 0.00000000000423 });
