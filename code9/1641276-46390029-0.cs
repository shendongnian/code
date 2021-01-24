    using (Image img = new Bitmap(Resources.Resources.router))
    {
       PointF imageLocation = new PointF(10, 10);
       img.RotateFlip(RotateFlipType.RotateNoneFlipXY);
       g.DrawImage(img, imageLocation);
    }
