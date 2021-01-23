    public static DataTable CreateDataTable(this IEnumerable<int> items, string colName)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(colName, typeof(int));
        foreach (int item in items)
        {
            dt.Rows.Add(item);
        }
        return dt;
    }
