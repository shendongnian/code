    private void grdDNSELECT_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        try
        {
            if (e.RowIndex == 0|| e.ColumnIndex==0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
        finally
        {
           //
        }
    }
