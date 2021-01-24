            private void Dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
    
                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
                {
                    //do something
                }
                else if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewTextBoxCell)
                {
                    //do something
                }
                else if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewImageCell)
                {
                    //do something
                }
                else
                {
                    //do something
                }
            }
