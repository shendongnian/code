    Graphics g= e.Graphics;
    using (var path = new GraphicsPath()) {
        path.AddLine(new Point(-4, 4), new Point(4, 4));
        path.AddLine(new Point(4, 4), new Point(0, -1));
        path.AddLine(new Point(0, -1), new Point(-4, 4));
        using (var cap = new CustomLineCap(path, null))
        using (var customCapPen = new Pen(Color.Black, 2) {CustomEndCap = cap}) { g.DrawLine(customCapPen, 10, 10, 10, 50); }
    }   
