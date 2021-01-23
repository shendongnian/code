        static class MyExtensions
    {
        public static string ToCSV(this DataTable dataTable, string rowFormat, string headFormat)
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendFormat(headFormat, columnNames.ToArray<string>());
            foreach (DataRow row in dataTable.Rows)
            {
                sb.AppendLine();
                sb.AppendFormat(rowFormat, row.ItemArray);
            }
            return sb.ToString();
        }
    }
