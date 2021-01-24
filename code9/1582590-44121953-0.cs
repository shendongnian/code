    private void datagridSB_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      int curRow = e.RowIndex;
      if (e.ColumnIndex == 1) {
        DataGridViewCheckBoxCell cbc = datagridSB.Rows[curRow].Cells[1] as DataGridViewCheckBoxCell;
        bool isChecked = (bool)cbc.EditedFormattedValue;
        if (isChecked) {
          datagridSB.Rows[curRow].Cells[2].Value = false;
        } else {
          datagridSB.Rows[curRow].Cells[2].Value = true;
        }
      }
      if (e.ColumnIndex == 2) {
        DataGridViewCheckBoxCell cbc = datagridSB.Rows[curRow].Cells[2] as DataGridViewCheckBoxCell;
        bool isChecked = (bool)cbc.EditedFormattedValue;
        if (isChecked) {
          datagridSB.Rows[curRow].Cells[1].Value = false;
        } else {
          datagridSB.Rows[curRow].Cells[1].Value = true;
        }
      }
    }
    private void datagridSB_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
      datagridSB_CellContentClick(sender, e);
    }
