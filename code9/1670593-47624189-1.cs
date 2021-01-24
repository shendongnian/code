    DataTable table = new DataTable();
    table.Columns.Add("FileName", typeof(string));
    table.Columns.Add("FilePath", typeof(string));
    for (int rows = 0; rows < dataGridView1.Rows.Count; rows++) {
      if (!dataGridView1.Rows[rows].IsNewRow &&
           dataGridView1.Rows[rows].Cells[0].Value != null &&
           dataGridView1.Rows[rows].Cells[1].Value != null) {
         table.Rows.Add(dataGridView1.Rows[rows].Cells[0].Value.ToString(), dataGridView1.Rows[rows].Cells[1].Value.ToString());
        }
      }
