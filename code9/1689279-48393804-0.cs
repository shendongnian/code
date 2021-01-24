        static public bool[][] GetSelectionState(this DataGridView input)
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
    Call it like this:
        bool[][] selectionState = MyDataGrid.GetSelectionState();
    Note: To work, `selectionState` must be a class-level variable, so that it persists between clicks.
