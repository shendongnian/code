    using System.Drawing.Drawing2D;
    ..
    private void dataGridView1_CellPainting(object sender, 
                                           DataGridViewCellPaintingEventArgs e)
    {
        Rectangle cr = e.CellBounds;
        e.PaintBackground(cr, true);
        Color c1 = Color.FromArgb(64, Color.PaleGoldenrod);
        Color c2 =   Color.FromArgb(64, e.State == DataGridViewElementStates.Selected ? 
                     Color.RosyBrown : Color.HotPink) ;
        if (e.RowIndex == 2 && (e.ColumnIndex >= 3))
            using (HatchBrush brush = new HatchBrush(HatchStyle.LargeConfetti, c1, c2))
            {
                e.Graphics.FillRectangle(brush, cr );
            }
        e.PaintContent(cr);
    }
