    public static void DataD() {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            int count = table.Columns.Count;
            var lastColumn = table.Columns[count - 1];
            string columnname = lastColumn.ColumnName;
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    var val = row[col].ToString();
                    var index = table.Columns.IndexOf(col);
                    if (columnname == col.ColumnName) {
                        // this is my last colums
                    }
                }
            }
        }
