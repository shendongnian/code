    Size sz = panel3.ClientSize;
    Point center = new Point(sz.Width / 2, sz.Height / 2);
    Graphics g = e.Graphics;
    // center point for testing only!
    g.DrawEllipse(Pens.Orange, center.X - 3, center.Y - 3, 6, 6);
    // you determine the value of the zooming!
    float zoom = (trackBar1.Value+1) / 3f;
    // move the scrolled center to the origon
    g.TranslateTransform(center.X + panel3.AutoScrollPosition.X, 
                            center.Y + panel3.AutoScrollPosition.Y);
    // scale the graphics
    g.ScaleTransform(zoom, zoom);
    // draw some stuff..
    using(Pen pen = new Pen(Color.Yellow, 0.1f))
    for (int i = -100; i < 100; i+= 10)
            g.DrawEllipse(Pens.Yellow, i-22,i-22,44,44);
