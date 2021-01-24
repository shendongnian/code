    private bool AreAllCellsFilled(DataTable t)
    {
        if (t == null || t.Rows.Count == 0 || t.Columns.Count == 0) return true;
        for (int rowIdx = 0; rowIdx < t.Rows.Count; rowIdx++)
        {
            for (int colIdx = 0; colIdx < t.Columns.Count; colIdx++)
            {
                if (t.Rows[rowIdx][colIdx] == DBNull.Value)
                {
                    MessageBox.Show($"Cell {colIdx + 1} of row {rowIdx + 1} is empty");
                    return false;
                }
            }
        }
        return true;
    }
