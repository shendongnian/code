    private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0/*myColumn*/ && e.RowIndex == 0 /*myRow*/)
            {
                myButton.Enable = true;
                //do other business
            } 
        }
