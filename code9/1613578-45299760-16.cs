    static Point scaledPoint(PictureBox pb, Point pt)
    {
        Rectangle r = ImageArea(pb);
        pt = new Point(pt.X  - r.Left, pt.Y - r.Top);
        float scaleX = 1f * pb.Image.Width / (pb.ClientSize.Width - 2 * r.Left) ;
        float scaleY = 1f * pb.Image.Height / (pb.ClientSize.Height - 2 * r.Top);
        return new Point((int)(pt.X * scaleX), (int)(pt.Y * scaleY));
    }
