    private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right )
            {
                //Set text to clipboard
                Clipboard.SetText( dataGridView[e.ColumnIndex, e.RowIndex].Value.ToString() );
            }
        }
