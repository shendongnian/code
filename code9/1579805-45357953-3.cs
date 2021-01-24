    namespace YourTestProject
    {
        public static class SpecFlowTableExtensions
        {
            public static DataTable ToDataTable(this Table table, params Type[] columnTypes)
            {
                DataTable dataTable = new DataTable();
                TableRow headerRow = table.Rows[0];
                int headerCellCount = headerRow.Count();
                for (int i = 0; i < headerCellCount; i++)
                {
                    string columnName = headerRow[i];
                    Type columnType = columnTypes[i];
                    dataTable.Columns.Add(columnName, columnType);
                }
                foreach (var row in table.Rows.Skip(1))
                {
                    var dataRow = dataTable.NewRow();
                    for (int i = 0; i < headerCellCount; i++)
                    {
                        string columnName = headerRow[i];
                        Type columnType = columnTypes[i];
                        dataRow[columnName] = Convert.ChangeType(row[i], columnType);
                    }
                    dataTable.AddRow(dataRow);
                }
                return dataTable;
            }
            public static DataTable ToDataTable(this Table table)
            {
                return table.ToDataTable<string>();
            }
            public static DataTable ToDataTable<TColumn0>(this Table table)
            {
                return table.ToDateTable(typeof(TColumn0));
            }
            public static DataTable ToDataTable<TColumn0, TColumn1>(this Table table)
            {
                return table.ToDateTable(typeof(TColumn0), typeof(TColumn1));
            }
            public static DataTable ToDataTable<TColumn0, TColumn1, TColumn2>(this Table table)
            {
                return table.ToDateTable(typeof(TColumn0), typeof(TColumn1), typeof(TColumn2));
            }
        }
    }
