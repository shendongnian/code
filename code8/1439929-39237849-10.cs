    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex == 1)
        {
            var rect = e.CellBounds;
            rect.Inflate(-1, 0);
            e.Paint(e.CellBounds, DataGridViewPaintParts.All
                & ~(DataGridViewPaintParts.ContentForeground));
            var text = string.Format("{0}", e.FormattedValue);
            //text = AutoEllipsis.Ellipsis.Compact(text, e.Graphics, e.CellBounds.Width,
            //    e.CellStyle.Font, AutoEllipsis.EllipsisFormat.Start);
            var size = TextRenderer.MeasureText(text, e.CellStyle.Font);
            var flags = TextFormatFlags.Left;
            if (size.Width > rect.Width)
                flags = TextFormatFlags.Right;
            TextRenderer.DrawText(e.Graphics, text, e.CellStyle.Font,
                rect, e.CellStyle.ForeColor, flags | TextFormatFlags.VerticalCenter);
            e.Handled = true;
        }
    }
