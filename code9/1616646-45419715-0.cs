    DataColumn[] columns = tbl.Columns.Cast<DataColumn>().ToArray();
    var enumerableRowCollection = tbl.AsEnumerable();
    DataRow firstRow = enumerableRowCollection.FirstOrDefault(
        row => columns.Any(col => row[col].ToString() == "PEPSI"));
    if (firstRow != null)
    {
        int rowIndex = tbl.Rows.IndexOf(firstRow);
    }
