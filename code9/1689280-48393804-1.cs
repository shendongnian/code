        static public void SetSelectionState(this DataGridView input, bool[][] selectionState)
        {
            for (int r = 0; r <= selectionState.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= selectionState[r].GetUpperBound(0); c++)
                {
                    input.Rows[r].Cells[c].Selected = selectionState[r][c];
                }
            }
        }
    And called it like this:
        private void MyDataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            _selectionState[e.RowIndex][e.ColumnIndex] = !_selectionState[e.RowIndex][e.ColumnIndex];
            MyDataGrid.SetSelectionState(_selectionState);
        }
