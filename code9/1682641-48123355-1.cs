    var selectColumns = dtRecord.Columns.Cast<DataColumn>().Take(10);
    var dtResult = new DataTable();
    foreach (var column in selectColumns)
        dtResult.Columns.Add(column.ColumnName);
    foreach (DataRow row in dtRecord.Rows)
        dtResult.Rows.Add(row.ItemArray.Take(10).ToArray());
