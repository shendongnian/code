    public static class DataTableExtensions
    {
        public static DataTable SetColumnsOrder(this DataTable table, string[] columnNames)
        {
            int columnIndex = 0;
            foreach (var columnName in columnNames)
            {
                if (table.Columns.Contains(columnName))
                {
                    table.Columns[columnName].SetOrdinal(columnIndex);
                    columnIndex++;
                }
            }
            return table;
        }
    }
