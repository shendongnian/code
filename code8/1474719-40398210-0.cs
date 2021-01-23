    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0)
            return;
        if(e.Value == null || e.Value == DBNull.Value)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All
                & ~(DataGridViewPaintParts.ContentForeground));
            TextRenderer.DrawText(e.Graphics, "Enter a value", e.CellStyle.Font,
                e.CellBounds, SystemColors.GrayText, TextFormatFlags.Left);
            e.Handled = true;
        }
    }
