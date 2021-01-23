    public static class CsvFileEx
    {
        public static void ToCsvFile(this DataTable dt, string filename, bool includeHeaders = true)
        {
            dt.ToCsvLines(includeHeaders: includeHeaders).WriteAsLinesToFile(filename);
        }
        public static IEnumerable<string> ToCsvLines(this DataTable dt, string seperator = @"""", bool includeHeaders = true)
        {
            if (includeHeaders)
                yield return string.Join(seperator, dt.Columns
                                                      .Cast<DataColumn>()
                                                      .Select(dc => @"""" + dc.ColumnName.Replace(@"""", @"""""") + @""""));
            foreach (var row in dt.Rows.Cast<DataRow>())
                yield return string.Join(seperator, row.ItemArray
                                                       .Select(i => @"""" + (i ?? "").ToString().Replace(@"""", @"""""") + @""""));
        }
        public static void WriteAsLinesToFile(this IEnumerable<string> lines, string filename)
        {
            using (var writer = new StreamWriter(filename))
                foreach (var line in lines)
                    writer.WriteLine(line);
        }
    }
