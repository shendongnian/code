     private void OnCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == this.columnValue.Index)
        {
            ... (check for null value as described above)
            else
            {
                e.Value = String.Format(e.Value, e.CellStyle.FormatProvider);
                e.FormattingApplied = true;
