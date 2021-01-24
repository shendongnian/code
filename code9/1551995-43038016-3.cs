    if (gridView1.CurrentCell.IsInEditMode)
    {
        if (gridView1.CurrentCell.GetType() == typeof(DataGridViewComboBoxCell))
        {
            if (!((DataGridViewComboBoxColumn)gridView1.Columns[e.ColumnIndex]).Items.Contains(e.FormattedValue))
            {
                ((DataGridViewComboBoxColumn)gridView1.Columns[e.ColumnIndex]).Items.Add(e.FormattedValue);
            }
        }
    }
