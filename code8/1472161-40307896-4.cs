    static class DataTableExtension
    {
        public static IEnumerable<DataRow> DistinctRow(this DataTable table)
        {
            return table
                .AsEnumerable()
                .Distinct(new DataRowComparer(table.Columns));
        }
    }
