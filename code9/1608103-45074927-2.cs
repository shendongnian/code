    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
          Point scrolledPoint = new Point( e.X - panel1.AutoScrollPosition.X, 
                                           e.Y - panel1.AutoScrollPosition.Y);
          ..
    }
