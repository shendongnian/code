    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
          Point scrolledPoint = new Point( e.X - panel2.AutoScrollPosition.X, 
                                           e.Y - panel2.AutoScrollPosition.Y);
          ..
    }
