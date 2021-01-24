    static Point scaledPoint(PictureBox pb, Point pt)
    {
        float scaleX = 1f * pb.Image.Width / pb.ClientSize.Width;
        float scaleY = 1f * pb.Image.Height / pb.ClientSize.Height;
        return  new Point((int)(pt.X * scaleX), (int)(pt.Y * scaleY));
    }
