    private static void CheckDataTable(DataTable dt)
    {
        var duplicateRows = dt.AsEnumerable()
            .GroupBy(r = > r[0])
            .Where(r = > r.Count() > 1)
            .SelectMany(r = > r.ToList())
            .ToList();
        
        duplicateRows.ForEach(r = > r["Duplicate"] = true);
    }
