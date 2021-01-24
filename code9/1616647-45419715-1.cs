    DataColumn[] columns = tbl.Columns.Cast<DataColumn>().ToArray();
    var enumerableRowCollection = tbl.AsEnumerable();
    var result = enumerableRowCollection
        .Select(x => new
        {
            Column = columns.FirstOrDefault(col => x[col].ToString() == "PEPSI"),
            Row = x
        })
        .Where(x => x.Column != null)
        .Select(x => new
        {
            ColumnIndex = columns.IndexOf(x.Column),
            RowIndex = tbl.Rows.IndexOf(x.Row)
        })
        .FirstOrDefault();
    if (firstRow != null)
    {
        int rowIndex = tbl.Rows.IndexOf(firstRow);
    }
