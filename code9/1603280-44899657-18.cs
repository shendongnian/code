    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
      if ((e.RowIndex >= 0) && (!dataGridView1.Rows[e.RowIndex].IsNewRow) ) {
        if (e.ColumnIndex >= 0) {
          if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit") {
            Form2 f2 = new Form2(dataGridView1, e.RowIndex);
            f2.ShowDialog();
          }
        }
      }
    }
