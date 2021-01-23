    public void ExportToExcel(DataTable table, string filename)
        {
            var lines = new List<string>();
            string[] columnNames = table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            var header = string.Join(",", columnNames);
            lines.Add(header);
            var valueLines = table.AsEnumerable().Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
            File.WriteAllLines(filename + ".csv", lines);
            DialogResult dialogResult = MessageBox.Show("File Successfully exported! Open now?", "Success", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string path = "...";
                System.Diagnostics.Process.Start(path);
            }
        }
