    g.FillRectangle(Brushes.Yellow, 15, 15, 10, 10);
    g.DrawRectangle(Pens.Orange, 10, 10, 10, 10);
    g.DrawLine(Pens.OrangeRed, 10, 5, 40, 5);
    using (Pen pen = new Pen(Color.Red, 2f) { DashStyle = DashStyle.Dot })
        g.DrawLine(pen, 10, 30, 48, 30);
    using (Pen pen = new Pen(Color.Crimson, 2f))
        g.DrawLine(pen, 10, 40, 48, 40);
    using (Pen pen = new Pen(Color.DarkMagenta, 3f))
        g.DrawLine(pen, 10, 50, 48, 50);
