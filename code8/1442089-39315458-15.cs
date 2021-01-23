    public struct HTMLTable
    {
        public string[] ColumnNames;
        public TableColumn[] ColumnValues;
        public HTMLTable(string[] columnNames, TableColumn[] columnValues)
        {
          ColumnNames = columnNames;
          ColumnValues = columnValues;
        }
    }
    public struct TableColumn
    {
        public string[] Values;
        public TableColumn(string[] values)
        {
          Values = values;
        }
    }
    public static class HTMLTableGenerator
    {
        public static string GenerateHTMLTable(HTMLTable Table)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<table>\n <tr>\n");
            foreach (string ColumnName in Table.ColumnNames)
                Builder.Append("  <th>" + ColumnName + "</th>\n");
            Builder.Append(" </tr>\n");
            foreach (var Column in Table.ColumnValues)
            {
                Builder.Append(" <tr>\n");
                foreach (string value in Column.Values)
                    Builder.Append("  <td>" + value + "</td>\n");
                Builder.Append(" </tr>\n");
            }
            Builder.Append("</table>");
            return Builder.ToString();
        }
    }
