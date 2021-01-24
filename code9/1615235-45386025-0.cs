    private void Form1_Load(object sender, EventArgs e) {
      SetColumns();
      FillGrid();
    }
    private void SetColumns() {
      for (int i = 0; i < 9; i++) {
        dataGridView1.Columns.Add("Col" + i, "Col" + i);
      }
    }
    private void FillGrid() {
      int newRowIndex = 0;
      for (int row = 0; row < 10; row++) {
        newRowIndex = dataGridView1.Rows.Add();
        for (int col = 0; col < dataGridView1.Columns.Count; col++) {
          dataGridView1.Rows[newRowIndex].Cells[col].Value = "R" + row + "C" + col;
        }
      }
    }
    private void button1_Click(object sender, EventArgs e) {
      foreach (DataGridViewRow curRow in dataGridView1.SelectedRows) {
        textBox1.Text += "--- New row ---" + Environment.NewLine;
        textBox1.Text += "Label1: " + curRow.Cells["Col2"].Value.ToString() + Environment.NewLine;
        textBox1.Text += "Label2: " + curRow.Cells["Col8"].Value.ToString() + Environment.NewLine;
        textBox1.Text += "Label3: " + curRow.Cells["Col6"].Value.ToString() + Environment.NewLine;
      }
    }
