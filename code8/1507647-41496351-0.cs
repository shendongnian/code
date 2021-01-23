    private void dgv_CellToolTipTextChanged(object sender, DataGridViewCellEventArgs e)
    {
        var grid = (DataGridView)sender;
        var toolTipControl = grid.GetType().GetField("toolTipControl",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance).GetValue(grid);
        var activated = (bool)toolTipControl.GetType()
            .GetProperty("Activated").GetValue(toolTipControl);
        if (activated)
        {
            var cell = grid[e.ColumnIndex, e.RowIndex];
            var ActivateToolTip = typeof(DataGridView).GetMethod("ActivateToolTip",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
            ActivateToolTip.Invoke(grid,
                new object[] { true, cell.ToolTipText, e.ColumnIndex, e.RowIndex });
        }
    }
