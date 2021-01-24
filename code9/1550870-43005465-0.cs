    private void Form1_Load(object sender, EventArgs e) {
      FillGrid();
      InsertButtonRow(0);
      InsertButtonRow(4);
      InsertButtonRow(dataGridView.Rows.Count -1);
    }
    private void FillGrid() {
      for (int i = 1; i < 15; i++) {
        dataGridView.Rows.Add("Row" + i + "C1", "Row" + i + "C2", "Row" + i + "C3");
      }
    }
       
    private void InsertButtonRow(int rowIndex) {
      if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count) {
        DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
        buttonCell.Value = "+";
        buttonCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        DataGridViewRow row = (DataGridViewRow)dataGridView.Rows[0].Clone();
        row.Cells[0] = buttonCell;
        dataGridView.Rows.Insert(rowIndex, row);
      }
    }
