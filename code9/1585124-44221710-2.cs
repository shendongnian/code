    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
      e.Control.KeyPress -= new KeyPressEventHandler(DoubleColumn_KeyPress);
      if (dataGridView1.CurrentCell.ColumnIndex == 1 || dataGridView1.CurrentCell.ColumnIndex == 2 ||
          dataGridView1.CurrentCell.ColumnIndex == 3 || dataGridView1.CurrentCell.ColumnIndex == 4 ||
          dataGridView1.CurrentCell.ColumnIndex == 5) {
        e.Control.KeyPress += new KeyPressEventHandler(DoubleColumn_KeyPress);
      }
    }
