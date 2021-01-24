    private void dataGridView_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
    {
        // Gets Your Row & Column, 4 is Jan in this case
        if ( e.ColumnIndex == 4 && e.RowIndex >= 0 )
        {
            // Do Your Validation
            // If False. Set 
            // e.Cancel = true;
            
        }
    }
