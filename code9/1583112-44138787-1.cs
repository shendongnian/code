    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0) return;  // only the column headers!
        // the hard work still can be done by the system:
        e.PaintBackground(e.CellBounds, true);
        e.PaintContent(e.CellBounds);
        // now for the lines in the header..
        Rectangle r = e.CellBounds;
        using (Pen pen0 = new Pen(dataGridView1.GridColor, 1))
        {
            // first vertical grid line:
            if (e.ColumnIndex < 0) e.Graphics.DrawLine(pen0, r.X, r.Y, r.X, r.Bottom);
            // right border of each cell:
            e.Graphics.DrawLine(pen0, r.Right - 1, r.Y, r.Right - 1, r.Bottom);
        }
        e.Handled = true;  // stop the system from any further work on the headers
    }
