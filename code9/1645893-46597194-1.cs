    object[] outRow = new object[dt.Columns.Count];
    Dictionary<string, bool> already = new Dictionary<string, bool>();
    bool test;
    using (var writer = conn.BeginTextImport("copy <table> from STDIN WITH NULL AS '' CSV"))
    {
        foreach (DataRow rw in dt.Rows)
        {
            for (int col = 0; col < dt.Columns.Count; col++)
                outRow[col] = rw[col];
            string output = string.Join(",", outRow);
            if (!already.TryGetValue(output, out test))
            {
                writer.WriteLine(output);
                already.Add(output, true);
            }
        }
    }
