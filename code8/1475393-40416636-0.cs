    private void myDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {
                var editedCell = myDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var otherCell = myDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (editedCell.Equals(otherCell))
                {
                    //Same
                }
         }
