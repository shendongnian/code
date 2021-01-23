    class MyRow
    {
        public string foo { get; set; }
        public string bar { get; set; }
    }
    var row = testData.Rows[1];
    var myRow = new MyRow();
    foreach (DataColumn col in testData.Columns)
    {
        var prop = typeof(MyRow).GetProperty(col.ColumnName);
        prop.SetValue(myRow, (string)(row[col] ?? string.Empty), null);
    }
