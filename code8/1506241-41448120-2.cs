    public DataTable Rotate(DataTable table)
    {
        var output = new DataTable();
        int i = 1;
        output.Columns.Add(" ");
        foreach (DataRow r in table.Rows)
            output.Columns.Add((i++).ToString());
        foreach (DataColumn c in table.Columns)
        {
            var list = new List<object>();
            list.Add(c.ColumnName);
            var x = table.AsEnumerable().Select(r => string.Format("{0}", r[c])).ToArray();
            list.AddRange(x);
            output.Rows.Add(list.ToArray());
        }
        return output;
    }
