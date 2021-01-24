    List<DataRow> rows = null;
    // Start population...
    var cols = table.Columns.Cast<DataColumn>.Where(c => string.IsNullOrEmpty(c.Expression));
    foreach (var col in cols)
    {
        List<object> values = GetValuesfromStream(theStream);
        // Create rows first if required.
        if (rows == null)
        {
            rows = new List<DataRow>();
            for (var i=0; i<values.Count; i++)
                rows.Add(table.NewRow());
        }
        // Actual method has some DBNull checking here, but should 
        // be immaterial to any solution.
        for (var i=0; i<values.Count; i++)
           rows[i][col] = values[i];
    }
    rows.ForEach(r => table.Rows.Add(r));
