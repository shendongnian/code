    private void dataGridView1_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
    {
        string headerText = 
            dataGridView1.Columns[e.ColumnIndex].HeaderText;
        // Abort validation if cell is not in the target column.
        // The target column is the column you want to validate
        if (!headerText.Equals("TargetColumn")) return;
        // Confirm that the cell is not empty.
        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
        {
            dataGridView1.Rows[e.RowIndex].ErrorText =
                "Your error message goes here.";
            e.Cancel = true;
        }
    }
