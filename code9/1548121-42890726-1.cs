    private void dataGridFoodMenu_CellContentClick(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 4) { 
        MessageBox.Show("EDIT button clicked at row: " + e.RowIndex);
      }
      else {
        if (e.ColumnIndex == 5) {
          MessageBox.Show("DELETE button clicked at row: " + e.RowIndex);
        }
        else {
          // buttons not clicked - ignoring
          //MessageBox.Show("Button cells were not clicked -- row: " + e.RowIndex + " Column: " + e.ColumnIndex);
        }
      }
    }
