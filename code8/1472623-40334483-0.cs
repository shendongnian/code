     private void PreTranslateDGV_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            DataGridViewTextBoxEditingControl a = (DataGridViewTextBoxEditingControl) sender;
            //a.PreviewKeyDown -= PreviewKeyDownEventHandler (dataGridView1_PreviewKeyDown)
            MyDataGridView s = (MyDataGridView) a.EditingControlDataGridView;
            if (e.KeyCode == Keys.Enter)
            {
                int newRow;
                int newColumn;
                if (s.CurrentCell.ColumnIndex == s.ColumnCount - 1)         // it's a last column, move to next row;
                {
                    newRow = s.CurrentCell.RowIndex + 1;
                    newColumn = 0;
                    if (newRow == s.RowCount)
                        s.Rows.Add(1); // ADD new row or RETURN (depends of your purposes..)
                }
                else                // just change current column. row is same
                {
                    newRow = s.CurrentCell.RowIndex;
                    newColumn = s.CurrentCell.ColumnIndex + 1;
                }
                s.CurrentCell = s.Rows[newRow].Cells[newColumn];
            }
        }
        private void PreTranslateDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.PreviewKeyDown -= PreTranslateDGV_PreviewKeyDown;
            tb.PreviewKeyDown += PreTranslateDGV_PreviewKeyDown;
            //e.Control.KeyDown += new KeyEventHandler(PreTranslateDGV_KeyPressEvent);
        }
