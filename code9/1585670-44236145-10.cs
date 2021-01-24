    static Point NearestCenterLocation(GraphicsPath gp, Size sz, Graphics g, int step)
    {
        RectangleF rB = gp.GetBounds();
        Point center = new Point((int)(rB.Left + rB.Width / 2f - sz.Width / 2), 
                                 (int)(rB.Top + rB.Height /2f - sz.Height/ 2));
        Point ncTL = center;      Point ncBR = center;
        Point ncT = center;       Point ncB = center;
        RectangleF nTLRect = new RectangleF(center, sz);
        RectangleF nBRRect = new RectangleF(center, sz);
        RectangleF nTRect = new RectangleF(center, sz);
        RectangleF nBRect = new RectangleF(center, sz);
        Point hit = Point.Empty;
        do
        {
            ncTL.Offset(-step, -step);
            ncBR.Offset(step, step);
            ncT.Offset(-step, 0);
            ncB.Offset(step, 0);
            nTLRect = new RectangleF(ncTL, sz);
            nBRRect = new RectangleF(ncBR, sz);
            nTRect = new RectangleF(ncT, sz);
            nBRect = new RectangleF(ncB, sz);
            hit = (PathContainsRect(gp, nTLRect, g) && ncTL.X > 0) ? ncTL : hit;
            hit = (PathContainsRect(gp, nBRRect, g) ) ? ncBR : hit;
            hit = (PathContainsRect(gp, nTRect, g)) ? ncT : hit;
            hit = (PathContainsRect(gp, nBRect, g) ) ? ncB : hit;
            g.DrawRectangle(Pens.Green, Rectangle.Round(nTLRect));  //  test only
            g.DrawRectangle(Pens.Blue, Rectangle.Round(nBRRect));   //  test only
            g.DrawRectangle(Pens.Cyan, Rectangle.Round(nTRect));    //  test only
            g.DrawRectangle(Pens.Khaki, Rectangle.Round(nBRect));   //  test only
        } while (hit == Point.Empty);
        g.DrawRectangle(Pens.Tomato, new Rectangle(center, sz));   //  test only
        return hit;
    }
