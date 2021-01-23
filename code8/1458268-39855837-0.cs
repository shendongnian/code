    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
        Rectangle r = e.CellBounds;
        using (Pen pen = new Pen(Color.DarkGoldenrod))
        {
            // top and left lines
            e.Graphics.DrawLine(pen, r.X, r.Y, r.X + r.Width, r.Y);
            e.Graphics.DrawLine(pen, r.X, r.Y, r.X, r.Y + r.Height);
            // last row? move hor.lines 1 up!
            int cy = e.Row == tableLayoutPanel1.RowCount - 1 ? -1 : 0;
            if (cy != 0) e.Graphics.DrawLine(pen, r.X, r.Y + r.Height + cy, 
                                    r.X + r.Width, r.Y + r.Height + cy);
            // last column ? move vert. lines 1 left!
            int cx = e.Column == tableLayoutPanel1.ColumnCount - 1 ? -1 : 0;
            if (cx != 0) e.Graphics.DrawLine(pen, r.X + r.Width + cx, r.Y, 
                                    r.X + r.Width + cx, r.Y + r.Height);
        }
    }
