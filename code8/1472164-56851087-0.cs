        public static DataTable GetDistinctRows(DataTable dataTable, string[][] fields, string newName)
        {
            DataTable result =
                new DataTable
                {
                    TableName = newName,
                    Locale = *
                };
            if (dataTable != null)
            {
                fields = fields
                    .Where(a => dataTable.Columns.Contains(a[0]))
                    .Select(a => a)
                    .ToArray();
                foreach (string[] field in fields)
                {
                    result.Columns.Add(dataTable.Columns[field[0]].ColumnName, dataTable.Columns[field[0]].DataType);
                    result.Columns[field[0]].Caption = field[1];
                }
                List<int> hashCodes = new List<int>();
                DataRowComparer<DataRow> comparer = DataRowComparer.Default;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = result.NewRow();
                    foreach (string[] field in fields)
                    {
                        row[field[0]] = dataTable.Rows[i][field[0]];
                    }
                    int hashCode = comparer.GetHashCode(row);
                    if (hashCodes.All(a => a != hashCode))
                    {
                        hashCodes.Add(hashCode);
                        result.Rows.Add(row);
                    }
                }
            }
            return result;
        }
