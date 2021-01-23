    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)        /*If a header cell*/
            return;
        if (!(e.ColumnIndex == 0 || e.ColumnIndex == 1) /*If not our desired columns*/
            return;
    
        if(e.Value == null || e.Value == DBNull.Value)  /*If value is null*/
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All
                & ~(DataGridViewPaintParts.ContentForeground));
            TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);
            e.Handled = true;
        }
    }
