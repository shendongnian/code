    Point p1 = Point.Empty;
    private void timer1_Tick(object sender, EventArgs e)
    {
        int deltaX = -3;
        int deltaY = -3;
        p1 = new Point(p1.X + deltaX , p1.Y + deltaY); // roll..
        if (p1.X < deltaX * 1000) p1 = Point.Empty;    // ..around
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        float angle = 33f;
        if (!timer1.Enabled) return;
        Rectangle rectG = new Rectangle(p1.X, p1.Y, 122, 22);
        Rectangle rectR = new Rectangle(22, 22, 222, 22);
        LinearGradientBrush lBrush = new LinearGradientBrush(rectG, 
                                         Color.Red, Color.Red, angle, false);
        ColorBlend cblend = new ColorBlend(5);
        cblend.Colors = new Color[5]  
             { Color.Red, Color.Pink, Color.MistyRose, Color.LightCoral, Color.White };
        cblend.Positions = new float[5] { 0f, 0.2f, 0.5f, 0.8f, 1f };
        lBrush.InterpolationColors = cblend;
        lBrush.WrapMode = WrapMode.TileFlipXY;
        e.Graphics.RotateTransform(angle);
        e.Graphics.TranslateTransform(22,11);
        e.Graphics.FillRectangle(lBrush, rectR);
    }
