    private void ItemsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == 2)
        {
            double result;
            if (!double.TryParse(e.FormattedValue.ToString(), out result))
            {
                e.Cancel = true;
                // Set error message
                ItemsDataGridView.Rows[e.RowIndex].ErrorText = "You have to enter doubles only";
            }
        }
    }
    private void ItemsDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
        // Clear error message
        ItemsDataGridView.Rows[e.RowIndex].ErrorText = null;
    }
