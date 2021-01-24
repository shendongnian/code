    private void CustInvLines_CellFormatting(object sender,
                                             DataGridViewCellFormattingEventArgs e)
    {
        var column = CustInvLines.Columns[e.ColumnIndex];
        if (column.Name == "InvLinePrice")
        {
            var cell = CustInvLines.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var value = (decimal)e.Value;
            if (cell.IsInEditMode)
            {
                e.Value = value.ToString(); // Display all digits
            }
            else
            {
                // Display only two digits of decimals without rounding
                e.Value = (Math.Truncate(value * 100)/100).ToString("C2");
            }
        }
    }
