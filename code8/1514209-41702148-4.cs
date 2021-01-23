    PointF stretched(Point p0, PictureBox pb)
    {
        if (pb.Image == null) return PointF.Empty;
        float scaleX = 1f * pb.Image.Width  / pb.ClientSize.Width;
        float scaleY = 1f * pb.Image.Height / pb.ClientSize.Height;
        return new PointF(p0.X * scaleX, p0.Y * scaleY);
    }
