    private void OnCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        if (e.RowIndex == -1) return;
        if (e.ColumnIndex == this.columnValue.Index)
        {
            decimal value;
            e.Cancel = !Decimal.TryParse((string)e.FormattedValue, out value);
        }
    }
