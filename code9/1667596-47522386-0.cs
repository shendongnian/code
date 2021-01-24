    static class SpecFlowExtensions
    {
        /// <summary>
        /// Converts a two column Gherkin data table to a dictionary
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));
            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Gherkin data table has no rows");
            if (table.Rows.First().Count != 2)
                throw new InvalidOperationException($@"Gherkin data table must have exactly 2 columns. Columns found: ""{string.Join(@""", """, table.Rows.First().Keys)}""");
            return table.Rows.ToDictionary(row => row[0], row => row[1]);
        }
    }
