    Pen pen = new Pen(Color.Black, 1f) { DashStyle = DashStyle.Dot };
    Point pa = new Point(10, 50);
    Point pb = new Point(70, 50);
    Point pc = new Point(70, 100);
    Point pd = new Point(10, 100);
    for (int i = 1; i < 10; i++ )
    {
        Dot = new Pen(Color.Black, i / 3f) { DashStyle = DashStyle.Dot };
        g.TranslateTransform(10, 10);
        DrawDottedLine(g, Dot, pa, pb);
        DrawDottedLine(g, Dot, pb, pc);
        DrawDottedLine(g, Dot, pc, pd);
        DrawDottedLine(g, Dot, pd, pa);
    }
