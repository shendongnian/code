    public static DataTable AsDataTable(this IEnumerable<IDictionary<string, object>> rows) {
        var dt = new DataTable();
        if (rows.Any()) {
            foreach (var kv in rows.First())
                dt.Columns.Add(kv.Key, kv.Value.GetType());
            foreach (var r in rows)
                dt.Rows.Add(r.Values.ToArray());
        }
        return dt;
    }
