    if (e.Button == System.Windows.Forms.MouseButtons.Left)
    {
        if (i == 0)
        {
            current = new Line();
            current.StartingPoint = new Point(e.X, e.Y);
        }
    }
