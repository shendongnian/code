    private void ItemsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.ColumnIndex == 2)
        {
            double result;
            if (!double.TryParse(e.FormattedValue.ToString(), out result))
            {
                e.Cancel = true;
            }
        }
    }
