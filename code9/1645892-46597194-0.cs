    object[] outRow = new object[dt.Columns.Count];
    using (var writer = conn.BeginTextImport("copy <table> from STDIN WITH NULL AS '' CSV"))
    {
        foreach (DataRow rw in dt.Rows)
        {
            for (int col = 0; col < dt.Columns.Count; col++)
                outRow[col] = rw[col];
            writer.WriteLine(string.Join(",", outRow));
        }
    }
