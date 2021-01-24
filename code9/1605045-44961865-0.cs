    private void DgNew_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                moveCellTo(dgNew, e.RowIndex, 1);
            }));
        }
    }
    
    private void moveCellTo(DataGridView dgCurrent, int rowIndex, int columnIndex)
    {
        dgCurrent.CurrentCell = dgCurrent.Rows[rowIndex].Cells[columnIndex];
    }
