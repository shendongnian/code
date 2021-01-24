    static public class Example
    {
        static private bool[][] GetSelectionState(DataGridView input)
        {
            int rowCount = input.Rows.Count;
            int columnCount = input.Columns.Count;
            var result = new bool[rowCount][];
            for (var r = 0; r < rowCount; r++)
            {
                result[r] = new bool[columnCount];
                for (var c = 0; c < columnCount; c++)
                {
                    var cell = input.Rows[r].Cells[c];
                    result[r][c] = cell.Selected;
                }
            }
            return result;
        }
        static private void SetSelectionState(DataGridView input, bool[][] selectionState)
        {
            for (int r = 0; r <= selectionState.GetUpperBound(0); r++)
            {
                for (int c = 0; c <= selectionState[r].GetUpperBound(0); c++)
                {
                    input.Rows[r].Cells[c].Selected = selectionState[r][c];
                }
            }
        }
        static public void SetupToggledSelectionMode(this DataGridView input)
        {
            bool[][] selectionState = GetSelectionState(input);  //This will be stored in a closure due to the lambda expressions below
            input.CellMouseUp += (object sender, DataGridViewCellMouseEventArgs e) =>
            {
                selectionState[e.RowIndex][e.ColumnIndex] = !selectionState[e.RowIndex][e.ColumnIndex];
                SetSelectionState(input, selectionState);
            };
            input.SelectionChanged += (object sender, EventArgs e) =>
            {
                if (selectionState != null)
                {
                    SetSelectionState(input, selectionState);
                }
            };
        }
    }
