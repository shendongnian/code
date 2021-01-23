    private void DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        var cell = dataGridView.CurrentCell;
        if (cell.ColumnIndex != 1)
            return;
        string value = cell.EditedFormattedValue.ToString();
        string pattern = @"^-$ | ^-?0$ | ^-?0\.\d*$ | ^-?[1-9]\d*\.?\d*$";
        if (Regex.IsMatch(value, pattern, RegexOptions.IgnorePatternWhitespace))
        {
            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        else
        {
            dataGridView.CancelEdit();
        }
    }
