    void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0)
            return;
        if (string.Format("{0}", e.Value) == "OK")
        {
            e.CellStyle.BackColor = Color.Red;
        }
    }
