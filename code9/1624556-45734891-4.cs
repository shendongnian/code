    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
         if (e.ColumnIndex == 2)
         {
                MessageBox.Show((e.RowIndex+1)  + "  Row  " + (e.ColumnIndex+1) + "  Column button clicked ");
         }
    }
