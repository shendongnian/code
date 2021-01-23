    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 1)
        {
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All
                & ~(DataGridViewPaintParts.ContentForeground));
            var text = string.Format("{0}", e.FormattedValue);
            text = AutoEllipsis.Ellipsis.Compact(text, e.Graphics, e.CellBounds.Width,
                e.CellStyle.Font, AutoEllipsis.EllipsisFormat.Start);
            TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font,
                e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.Right);
            e.Handled = true;
        }
    }
