    private void Form_DGV_DataTable_Load(object sender, EventArgs e) {
      dt = Utilities.GetTableWithPlayers(filePath);
      dataGridView1.DataSource = dt;
      UpdatePoints();
    }
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 3)
        UpdatePoints();
    }
    private void UpdatePoints() {
      int total = 0;
      int curInt = 0;
      foreach (DataGridViewRow row in dataGridView1.Rows) {
        if (row.Cells["Points"].Value != null) {
          int.TryParse(row.Cells["Points"].Value.ToString(), out curInt);
          total += curInt;
        }
      }
      textBox1.Text = total.ToString();
    }
