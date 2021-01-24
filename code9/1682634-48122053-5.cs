    public static DataTable AsDataTable(this IEnumerable<IDictionary<string, object>> rows) {
        var dt = new DataTable();
        if (rows.Count() > 0) {
            foreach (var kv in rows.First())
                dt.Columns.Add(kv.Key, kv.Value.GetType());
            foreach (var r in rows)
                dt.Rows.Add(dt.NewRow().ItemArray = r.Values.ToArray());
        }
        return dt;
    }
    public static DataTable AsDataTable(this IEnumerable<Dictionary<string, object>> rows) => ((IEnumerable<IDictionary<string, object>>)rows).AsDataTable();
