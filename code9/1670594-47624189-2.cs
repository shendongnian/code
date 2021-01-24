    DataTable table = new DataTable();
    table.Columns.Add("FileName", typeof(string));
    table.Columns.Add("FilePath", typeof(string));
    DataRow newRow;
    if (dataGridView1.Columns.Count >= table.Columns.Count) {
      for (int row = 0; row < dataGridView1.Rows.Count; row++) {
        if (!dataGridView1.Rows[row].IsNewRow) {
          newRow = table.NewRow();
          for (int col = 0; col < table.Columns.Count; col++) {
            if (dataGridView1.Rows[row].Cells[col].Value != null)
              newRow[col] = dataGridView1.Rows[row].Cells[col].Value.ToString();
            else
              newRow[col] = "";
          }
          table.Rows.Add(newRow);
        }
      }
    }
