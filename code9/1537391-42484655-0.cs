    public void colocar(Point p, Control control)
    {
        using (Graphics g = control.CreateGraphics())
        {
            using (Pen pen = new Pen(Color.Red, 2))
            {
                g.DrawRectangle(pen, p.X, p.Y, 20, 20);
            }
        }
    }
