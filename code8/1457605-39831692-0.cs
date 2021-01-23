    protected override void OnPaint (PaintEventArgs e) {
       Graphics g = e.Graphics;
       g.DrawLine (Dot, new Point (10, 50), new Point (70, 50));
       g.DrawLine (Dot, new Point (69, 49), new Point (69, 100));
    }
    
    Pen Dot = new Pen (Brushes.Black, 2) { DashStyle = DashStyle.Dot };
