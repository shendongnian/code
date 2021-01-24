    static Point scaledPoint(PictureBox pb, Point pt)
    {
        float scaleX = 1f * pb.Image.Width / pb.ClientSize.Width;
        float scaleY = 1f * pb.Image.Height / pb.ClientSize.Height;
        Rectangle r = ImageArea(pb);
        pt = new Point(pt.X  - r.Left, pt.Y - r.Top);
        Point sPt = new Point((int)(pt.X * scaleX), (int)(pt.Y * scaleY));
        return new Point( sPt.X , sPt.Y);
    }
