    public void wbDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.RowIndex != -1) // added this and it now works
                {
                    this.rowIndex = e.RowIndex;
                    this.colIndex = e.ColumnIndex;
                    this.wbDataGridView = (DataGridView)sender;
                    return;
                }
    
                if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex != -1)
                {
                    this.rowIndex = e.RowIndex;
                    this.colIndex = e.ColumnIndex;
                    this.wbDataGridView = (DataGridView)sender;
                    return;
                }
            }
