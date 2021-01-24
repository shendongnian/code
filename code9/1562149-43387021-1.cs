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
      textBox1.Text = dt.Compute("SUM(Points)", "").ToString();
    }
