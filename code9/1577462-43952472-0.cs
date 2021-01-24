    private void Form1_Load(object sender, EventArgs e) {
      SetColumns();
      AddRows();
    }
    private void SetColumns() {
      DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn();
      comboColumn.Name = "Grade";
      comboColumn.HeaderText = "Grade";
      comboColumn.ValueMember = "Grade";
      comboColumn.DisplayMember = "Grade";
      dataGridView1.Columns.Add(comboColumn);
      dataGridView1.Columns.Add("ID", "ID");
    }
    private void AddRows() {
      int newRowIndex = dataGridView1.Rows.Add();
      dataGridView1.Rows[newRowIndex].Cells[1].Value = 1;
      newRowIndex = dataGridView1.Rows.Add();
      dataGridView1.Rows[newRowIndex].Cells[1].Value = 2;
      newRowIndex = dataGridView1.Rows.Add();
      dataGridView1.Rows[newRowIndex].Cells[1].Value = 3;
    }
  
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      try {
        if (e.ColumnIndex == 1) {
          if (dataGridView1.Rows[e.RowIndex].Cells[1].Value != null) {
            DataGridViewComboBoxCell comboCell = dataGridView1.Rows[e.RowIndex].Cells[0] as DataGridViewComboBoxCell;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "1") {
              SetCombo(1, comboCell);
            } else {
              if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() == "2") {
                SetCombo(2, comboCell);
              } else {
                SetCombo(3, comboCell);
              }
            }
          }
        }
      }
      catch (Exception ex) {
        MessageBox.Show("Error: " + ex.Message);
      }
    }
    private void SetCombo(int comboType, DataGridViewComboBoxCell comboCell) {
      comboCell.Value = "";
      comboCell.Items.Clear();
      if (comboType == 1) {
        comboCell.Items.Add("A");
        comboCell.Items.Add("B");
        comboCell.Items.Add("C");
        return;
      }
      if (comboType == 2) {
        comboCell.Items.Add("D");
        comboCell.Items.Add("E");
        comboCell.Items.Add("F");
        return;
      }
      comboCell.Items.Add("A");
      comboCell.Items.Add("B");
      comboCell.Items.Add("C");
      comboCell.Items.Add("D");
      comboCell.Items.Add("E");
      comboCell.Items.Add("F");
    }
