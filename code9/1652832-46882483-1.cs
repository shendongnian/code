    private void PrintGridToCSV(DataGridView grid, string fileName) {
      if (grid != null && grid.Columns.Count > 0 && grid.Rows.Count > 0) {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(GetCommaDelimitedRow(grid, -1));  // <- add column headers row
        for (int i = 0; i < grid.Rows.Count; i++) {
          if (!grid.Rows[i].IsNewRow)
            sb.AppendLine(GetCommaDelimitedRow(grid, i)); // <- add row data
        }
        try {
          File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
        }
        catch (Exception e) {
          MessageBox.Show("File write error: " + e.Message);
        }
      }
      else
        MessageBox.Show("Grid is null... has no columns or has no rows or both!");
    }
    private void button1_Click(object sender, EventArgs e) {
      PrintGridToCSV(dataGridView1, @"D:\Test\_MyCSVFile.csv");
    }
