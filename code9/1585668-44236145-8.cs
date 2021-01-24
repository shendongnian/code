    Size sz = new Size(70, 35);
    GraphicsPath gp1 = new GraphicsPath();
    gp1.FillMode = FillMode.Winding;
    gp1.AddRectangle(new Rectangle(0, 0, 350, 120));
    gp1.AddRectangle(new Rectangle(0, 0, 120, 300));
    gp1.AddRectangle(new Rectangle(250, 0, 100, 300));
    Point px = NearestCenterLocation(gp1, sz, g , 10);
    using (SolidBrush brush = new SolidBrush(Color.FromArgb(66, Color.Gold)))
        g.FillPath(brush, gp1);
    g.DrawRectangle(Pens.Tomato, new Rectangle(px, sz));
