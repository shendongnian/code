    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var points = new []
        {              
            new PointF(150, 250),
            new PointF( 50, 500),
            new PointF(250, 400),
            new PointF(300, 100),
            new PointF(500, 500),
            new PointF(500,  50),
        };
        using (var path = new GraphicsPath())
        {
            path.AddPolygon(points);
            // Uncomment this to invert:
            // p.AddRectangle(this.ClientRectangle);
            using (var brush = new SolidBrush(Color.Black))
            {
                e.Graphics.FillPath(brush, path);
            }
        }
    }
