    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        Graphics g = e.Graphics;
            Pen blue = new Pen(Color.Blue);
            Pen red = new Pen(Color.Red);
            Rectangle rect = new Rectangle(50 + ((x-1) * 100), 50, 50, 50);
            g.DrawEllipse(blue, rect);
    
    }
