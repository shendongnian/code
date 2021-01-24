    public static DataTable Slice(this DataTable dt, params string[] colnames) {
        var newTable = new DataTable();
        foreach (var c in colnames)
            newTable.Columns.Add(c, dt.Columns[c].DataType);
        foreach (var r in dt.AsEnumerable())
            newTable.Rows.Add(colnames.Select(c => r[c]).ToArray());
        return newTable;
    }
