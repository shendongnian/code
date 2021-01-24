    public class TableDataRow
    {
        public TableDataRow(List<string> cells)
        {
            Cells = cells;
        }
        public List<string> Cells { get; }
    }
    public class TableData
    {
        public TableData(List<string> columnHeaders, List<TableDataRow> rows)
        {
            for (int i = 0; i < rows.Count; i++)
                if (rows[i].Cells.Count != columnHeaders.Count)
                    throw new ArgumentException(nameof(rows));
            ColumnHeaders = columnHeaders;
            Rows = rows;
        }
        public List<string> ColumnHeaders { get; }
        public List<TableDataRow> Rows { get; }
    }
