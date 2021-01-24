    DataTable result = dt.Rows.Cast<DataRow>().ToLookup(r => r[0])
        .Aggregate(dt.Clone(), (t, g) => t.Rows.Add(Enumerable.Range(0, t.Columns.Count)
        .Select(i => i < 1 ? g.Key : g.Sum(r => (int)r[i])).ToArray()).Table);
---
    Debug.Print(string.Join("\t", result.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
    Debug.Print(string.Join("\n", result.Rows.Cast<DataRow>().Select(r => string.Join("\t\t", r.ItemArray))));
