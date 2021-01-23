    private void DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        var cell = dataGridView.CurrentCell;
        string pattern = @"^-$ | ^-?\d+\.?\d*$";
        string value = cell.EditedFormattedValue.ToString();
        if (Regex.IsMatch(value, pattern, RegexOptions.IgnorePatternWhitespace))
        {
            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        else
        {
            dataGridView.CancelEdit();
        }
    }
